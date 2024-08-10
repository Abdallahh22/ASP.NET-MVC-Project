using Microsoft.AspNetCore.Mvc;
using MVC_Project.BLI.Repostories;
using MVC_Project.BLI.Interefaces;
using MVC_Project.DAL.Models;
using MVC_Project.BLI.Interfaces;
using AutoMapper;
using System.Linq;
using MVC_project.PL.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace MVC_project.PL.Controllers
{
	[Authorize]

	public class DepartmentController : Controller
    {

        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dept = Enumerable.Empty<Department>();
            var department = _unitOfWork.DepartmentRepository.GetAll();
            _unitOfWork.Complete();
            var result = _mapper.Map<IEnumerable<DepartmentViewModel>>(department);
            return View(result);

        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(Department department , DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
               var dept = _mapper.Map<Department>(model);
                _unitOfWork.DepartmentRepository.Add(dept);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int? id, string view = "Details")
        {
            if (id is null)
                return BadRequest();
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            var result = _mapper.Map<DepartmentViewModel>(department);
            if (department is null)
                return NotFound();
            _unitOfWork.Complete();
            return View(view, result);
        }
        [HttpGet]
        public IActionResult Update(int? id, string view = "Update")
        {
            if (id is null)
                return NotFound();
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            var result = _mapper.Map<DepartmentViewModel>(department);
            if (department is null)
                return NotFound();
            _unitOfWork.Complete();
            return View(view, result);
        }


        [HttpPost]
        public IActionResult Update(int id, DepartmentViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            var result = _mapper.Map<Department>(model);

            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.DepartmentRepository.Update(result);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index");


                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            } 
            return View(model);
        }

        public IActionResult Delete(int? id , DepartmentViewModel model)
        {
            if (id is null)
                return NotFound();
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            var result = _mapper.Map<Department>(model);
            if (result is null)
                return NotFound();
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
        }

    }


}

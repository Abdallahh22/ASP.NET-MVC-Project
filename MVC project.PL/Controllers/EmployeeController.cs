using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_project.PL.ViewModels;
using MVC_Project.BLI.Interfaces;
using MVC_Project.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_project.PL.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork = unitOfWork;
           _mapper = mapper;
        }

        public IActionResult Index(string search)
        {
            var employees = Enumerable.Empty<Employee>();
            if (string.IsNullOrEmpty(search))
            {
                 employees = _unitOfWork.EmployeeRepository.GetAll();
            }
            else
            {
                
                employees = _unitOfWork.EmployeeRepository.Search(search);
            }
          var result =  _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return View(result);
        }

        public IActionResult create()
        {
            ViewData["Departments"] = _unitOfWork.DepartmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
             var employee =   _mapper.Map<Employee>(model);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
                
            }
            return View(model);
        }

        public IActionResult Details(int? id, string view = "Details")
        {
            if (id is null)
                return BadRequest();
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            var EmployeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            if (employee is null)
                return NotFound();
            _unitOfWork.Complete();
            return View(view, EmployeeViewModel);
        }

        public IActionResult Update(int? id, string view = "Update")
        {
            ViewData["Departments"] = _unitOfWork.DepartmentRepository.GetAll();
            if (id is null)
                return BadRequest();
            var employees = _unitOfWork.EmployeeRepository.GetById(id.Value);
            var employee = _mapper.Map<EmployeeViewModel>(employees);

            if (employee is null)
                return NotFound();
            _unitOfWork.Complete();
            return View(view , employee);

        }

        [HttpPost]
        public IActionResult Update(int id, EmployeeViewModel model)
        {
            ViewData["Departments"] = _unitOfWork.DepartmentRepository.GetAll();
            if (id != model.Id)
                return BadRequest();
                var employee = _mapper.Map<Employee>(model);
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.EmployeeRepository.Update(employee);
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


        public IActionResult Delete(int? id , EmployeeViewModel model)
        {
            if (id is null)
                return NotFound();
            var employees = _unitOfWork.EmployeeRepository.GetById(id.Value);
            var employee = _mapper.Map<Employee>(model);
            if (employee is null)
                return NotFound();
            _unitOfWork.EmployeeRepository.Delete(employees);
            _unitOfWork.Complete();
            return RedirectToAction("Index");
           

        }
    }
}

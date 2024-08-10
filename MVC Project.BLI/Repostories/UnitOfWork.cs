using MVC_Project.BLI.Interefaces;
using MVC_Project.BLI.Interfaces;
using MVC_Project.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.BLI.Repostories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public IDepartmentRepository DepartmentRepository { get ; set ; }
        public IEmployeeRepository EmployeeRepository { get; set ; }

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            DepartmentRepository = new DepartmentRepository(context);
            EmployeeRepository = new EmployeeRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

    }
}

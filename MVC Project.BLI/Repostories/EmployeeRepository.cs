using MVC_Project.BLI.Interfaces;
using MVC_Project.DAL.Data;
using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.BLI.Repostories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private AppDBContext _context;

        public EmployeeRepository(AppDBContext dbcontext) : base(dbcontext) 
        {
          _context = dbcontext;
        }

        public IEnumerable<Employee> Search(string name)
        {
            var search = _context.Employees.Where(e => e.Name.Trim().ToLower().Contains(name.Trim().ToLower()));
            return search;
        }
    }
}

using MVC_Project.BLI.Interefaces;
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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
      
        public DepartmentRepository(AppDBContext contxt) :base(contxt) 
        {
           
        }

     
    }
}

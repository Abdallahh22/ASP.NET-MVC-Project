using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Project.DAL.Models;
using MVC_Project.BLI.Interfaces;

namespace MVC_Project.BLI.Interefaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
       
    }
}

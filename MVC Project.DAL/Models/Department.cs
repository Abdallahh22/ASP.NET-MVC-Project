using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.DAL.Models
{
    public class Department : BaseEntity
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public DateTime DateofCreation { get; set; }
        public ICollection<Employee> Employees { get; set; } 
    }
}

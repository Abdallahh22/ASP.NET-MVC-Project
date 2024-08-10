using MVC_Project.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace MVC_project.PL.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateofCreation { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}

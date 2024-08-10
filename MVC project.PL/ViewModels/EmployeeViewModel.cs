using MVC_Project.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace MVC_project.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Max length must be 50 char")]
        [MinLength(5, ErrorMessage = "Min length must be 5 char")]
        [DisplayName("Employee Name")]
        public string Name { get; set; }

        [Range(20, 35, ErrorMessage = "Your Age Must between 20 : 35")]
        public int? Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        [DisplayName("Departments")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}

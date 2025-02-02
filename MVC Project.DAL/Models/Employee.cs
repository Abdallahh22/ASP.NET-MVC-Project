﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.DAL.Models
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email{ get; set; }
        public bool IsActive { get; set; } 
        public string PhoneNumber { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}

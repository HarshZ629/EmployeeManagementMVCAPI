using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagementAPI.Models.Employee
{
    public class Emp_Detail
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }

        public string EmpPassword { get; set; }
        public string EmpDetails { get; set; }
        public string EmpSalary { get; set; }
        public string EmpDesignation { get; set; }
        public string EpLocation { get; set; }
    }
}
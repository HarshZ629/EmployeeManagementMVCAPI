using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EmployeeManagementAPI.Models.Employee;
using EmployeeManagementAPI.Models.Admin;

namespace EmployeeManagementAPI.Data
{
    public class Context : DbContext
    {
        public Context() :base("Context")
        {
                
        }

        public DbSet<Admin_details> Admin { get; set; }
        public DbSet<Emp_Detail> Employee { get; set; }

    }
}
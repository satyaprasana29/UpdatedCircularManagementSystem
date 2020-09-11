﻿using CircularManagementSystem.Entity;
using System.Data.Entity;
namespace CircularManagementSystem.DAL
{
    class ContextClass:DbContext
    {
        public ContextClass():base("connectionString")
        {

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDesignation> EmployeeDesignations { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Circular> Circulars { get; set; }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WarehouseManagement.Domain.Context;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure
{
    public class WarehouseContext : DatabaseContext
    {
        public WarehouseContext()
        {
        }

        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordItem> RecordItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
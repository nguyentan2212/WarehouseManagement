using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Domain.Context
{
    public class DatabaseContext : IdentityDbContext<Employee, EmployeeType, Guid>
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}

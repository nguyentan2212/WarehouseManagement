using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WarehouseManagement.Domain.Entities
{
    public class Employee : IdentityUser<Guid>
    {
        public string Name { get; set; }

        public List<Record> Records { get; set; }
    }
}
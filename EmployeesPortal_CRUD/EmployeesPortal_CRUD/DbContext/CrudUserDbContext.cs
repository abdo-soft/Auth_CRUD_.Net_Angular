using EmployeesPortal_CRUD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesPortal_CRUD.DBContext
{
    public class CrudUserDbContext : IdentityDbContext<ApplicationUser>
    {
        public CrudUserDbContext(DbContextOptions<CrudUserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }

}

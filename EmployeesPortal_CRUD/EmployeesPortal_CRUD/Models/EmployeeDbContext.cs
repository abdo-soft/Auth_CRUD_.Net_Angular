using EmployeesPortal_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace EmployeesPortal_CRUD.Models
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().ToTable("Employee");
        }


        public Microsoft.EntityFrameworkCore.DbSet<Employee> Employee { get; set; }
        
        
        
        
        
        
        //protected readonly IConfiguration Configuration;
        //public EmployeeDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    //object value = options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //}
        //public virtual Microsoft.EntityFrameworkCore.DbSet<Employee>? Employees { get; set; }
        //public virtual Microsoft.EntityFrameworkCore.DbSet<User>? UserInfos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<User>(entity =>
        //    //{

        //    //});

        //    //modelBuilder.Entity<Employee>(entity =>
        //    //{

        //    //});

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject.Entities
{
    public class NorthwindContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        public NorthwindContext(DbContextOptions<NorthwindContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}

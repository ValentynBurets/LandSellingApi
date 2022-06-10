using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class DesignTimeContext : IDesignTimeDbContextFactory<LandSellingContext>
    {
        public LandSellingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LandSellingContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=LandSellingContext;Integrated Security=True");
            return new LandSellingContext(optionsBuilder.Options);


        }
    }
}

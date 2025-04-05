using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Context
{
    public class DataContextFactory  //:IDesignTimeDbContextFactory<DataContext>
    {
        //public DataContextFactory CreateDbContext(string[] args)
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Foody.DAL"))
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");

        //    optionsBuilder.UseSqlServer(connectionString);

        //    return new DataContext(optionsBuilder.Options);
        //}
    }
}
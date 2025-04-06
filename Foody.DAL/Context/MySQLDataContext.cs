using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.DAL.Context
{
    public class MySQLDataContext:DbContext
    {
        public MySQLDataContext(DbContextOptions<MySQLDataContext> options) : base(options)
        {
        }


    }
}

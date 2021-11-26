using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using WebApiTestDb.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Metering.DAL
{
    public class AppDBContext : DbContext
    {
        //public DbSet<Depts> Dept { get; set; }
        public AppDBContext(DbContextOptions x) : base(x)
        {
        }
    }
}

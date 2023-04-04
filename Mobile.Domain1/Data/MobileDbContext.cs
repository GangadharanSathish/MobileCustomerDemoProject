using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mobile.Domain1.Model;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Domain1.Data
{
    public class MobileDbContext : DbContext
    {
        public MobileDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<mobile> mobiles { get; set; }

        public DbSet<customer> customers { get; set; }
    }
}

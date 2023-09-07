using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) :base(options)
        {

        }

       
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}

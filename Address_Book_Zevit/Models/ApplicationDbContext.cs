using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_Book_Zevit.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; }
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

    }
}

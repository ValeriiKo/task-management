using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebIdentity.Models;

namespace WebIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<Manager>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Manager> Manager { get; set; }
        public DbSet<Problem> Problem { get; set; }
    }
}

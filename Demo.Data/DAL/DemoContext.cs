using System;
using System.Collections.Generic;
using System.Text;
using Demo.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data.DAL
{
    public class DemoContext : IdentityDbContext<User>
    {
        public DemoContext(DbContextOptions<DemoContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<News> News { get; set; }

    }
}
using IdentityCase.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IdentityCase.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOPCENG\\SQLEXPRESS;Initial Catalog=IdentityCase;Integrated Security=True; trust server certificate = true");
        }


        public DbSet<Message> Messages { get; set; }
    }
}

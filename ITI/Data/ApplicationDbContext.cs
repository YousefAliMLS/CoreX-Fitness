using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ITI.Models;

namespace ITI.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserApplication>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}

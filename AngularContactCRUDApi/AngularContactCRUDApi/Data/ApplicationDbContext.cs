using AngularContactCRUDApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularContactCRUDApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

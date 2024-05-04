
using email_verifier_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace email_verifier_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Emails> emails { get; set; }
    }

}

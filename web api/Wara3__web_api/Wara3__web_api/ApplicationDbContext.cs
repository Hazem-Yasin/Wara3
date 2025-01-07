using Microsoft.EntityFrameworkCore;

namespace Wara3__web_api

{
    using Microsoft.EntityFrameworkCore;
    using Wara3__web_api.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // جداول قاعدة البيانات
        public DbSet<User> Users { get; set; }
        public DbSet<Addiction> Addictions { get; set; }
    }

}
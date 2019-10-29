using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ToWriteList.Context
{
    public class ToWriteDbContext : DbContext
    {
        private JToken Config => JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
        private string ConnectionString => Config["ConnectionStrings"]["DefaultConnection"].ToString();
        public ToWriteDbContext()
        {
        }

        public ToWriteDbContext(DbContextOptions<ToWriteDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}

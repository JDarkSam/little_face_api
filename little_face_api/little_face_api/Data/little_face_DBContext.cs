using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using little_face_api.Data.Models;

namespace little_face_api.Data
{
    public class little_face_DBContext : DbContext
    {
        public little_face_DBContext (DbContextOptions<little_face_DBContext> options)
            : base(options)
        {
        }

        public DbSet<little_face_api.Data.Models.Client> Clients { get; set; } = default!;
        public DbSet<little_face_api.Data.Models.UserRole> UserRoles { get; set; } = default!;

        public DbSet<little_face_api.Data.Models.User> Users { get; set; } = default!;

        public DbSet<little_face_api.Data.Models.Child> Childs { get; set; } = default!;

        public DbSet<little_face_api.Data.Models.Goal> Goals { get; set; } = default!;

        public DbSet<little_face_api.Data.Models.Reward> Rewards { get; set; } = default!;

        public DbSet<little_face_api.Data.Models.GoalChild> GoalChilds { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));
            modelBuilder.Entity<UserRole>().ToTable(nameof(UserRole));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<Child>().ToTable(nameof(Child));
            modelBuilder.Entity<Goal>().ToTable(nameof(Goal));
            modelBuilder.Entity<Reward>().ToTable(nameof(Reward));
            modelBuilder.Entity<GoalChild>().ToTable(nameof(GoalChild));

            base.OnModelCreating(modelBuilder);
        }

    }
}

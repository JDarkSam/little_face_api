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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable(nameof(Client));           

            base.OnModelCreating(modelBuilder);
        }

    }
}

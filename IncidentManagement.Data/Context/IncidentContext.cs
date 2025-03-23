using System.Data.Entity;
using IncidentManagement.Entities.Models;

namespace IncidentManagement.Data.Context
{
    public class IncidentContext : DbContext
    {
        public IncidentContext() : base("name=IncidentConnection")
        {
        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuración de relaciones
            modelBuilder.Entity<Incident>()
                .HasRequired(i => i.Reporter)
                .WithMany(u => u.ReportedIncidents)
                .HasForeignKey(i => i.ReporterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Incident>()
                .HasOptional(i => i.AssignedTechnician)
                .WithMany(u => u.AssignedIncidents)
                .HasForeignKey(i => i.AssignedTechnicianId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasRequired(c => c.Incident)
                .WithMany(i => i.Comments)
                .HasForeignKey(c => c.IncidentId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Comment>()
                .HasRequired(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
} 
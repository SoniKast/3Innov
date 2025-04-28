using AdminInterface.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminInterface.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<GroupeMonitoring> GroupeMonitoring { get; set; }
        public DbSet<Equipement> Equipement { get; set; }
        public DbSet<Incident> Incident { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipement>()
                .HasKey(e => e.ID_Equipement);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Utilisateur)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.ID_Utilisateur);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Incident)
                .WithMany()
                .HasForeignKey(t => t.ID_Incident);

            modelBuilder.Entity<Equipement>()
                .HasOne(e => e.Groupe)
                .WithMany(g => g.Equipements)
                .HasForeignKey(e => e.ID_Groupe);

            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Equipement)
                .WithMany(e => e.Incidents)
                .HasForeignKey(i => i.ID_Equipement);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName()!.ToLowerInvariant());
            }
        }

    }
}

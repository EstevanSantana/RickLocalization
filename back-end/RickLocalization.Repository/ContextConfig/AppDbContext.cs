using Microsoft.EntityFrameworkCore;
using RickLocalization.Domain;

namespace RickLocalization.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Rick> Rick { get; set; }
        public DbSet<Dimensao> Dimencao { get; set; }
        public DbSet<Viagem> Viagem { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Rick>()
                    .HasOne(x => x.Origem)
                        .WithOne(x => x.Rick)
                            .IsRequired(false);

            model.Entity<Viagem>()
                    .HasOne<Rick>(x => x.Rick)
                       .WithMany(x => x.Viagens)
                            .HasForeignKey(x => x.RickId);

            model.Entity<Viagem>()
                    .HasOne(x => x.Dimensao)
                        .WithOne(x => x.Viagem)
                            .IsRequired(false);

            

            base.OnModelCreating(model);
        }

    }
}

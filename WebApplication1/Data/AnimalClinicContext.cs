namespace WebApplication1.Data
{
    using Microsoft.EntityFrameworkCore;
    using WebApplication1.Models;

    public class AnimalClinicContext : DbContext
    {
        public virtual required DbSet<Animal> Animals { get; set; }
        public virtual required DbSet<AnimalTypes> AnimalTypes { get; set; }
        public virtual required DbSet<Employee> Employees { get; set; }
        public virtual required DbSet<Visit> Visits { get; set; }

        public AnimalClinicContext(DbContextOptions<AnimalClinicContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Animal");
                entity.Property(a => a.ConcurrencyToken)
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<AnimalTypes>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("AnimalTypes");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Employee");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("Visit");
                entity.Property(v => v.ConcurrencyToken)
                    .IsConcurrencyToken();
            });
        }
    }
}
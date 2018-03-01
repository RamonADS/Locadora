namespace VideoLocadora.Dados
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Locadora_Modelo : DbContext
    {
        public Locadora_Modelo()
            : base("name=Locadora_Modelo")
        {
        }

        public virtual DbSet<Aluguel> Aluguel { get; set; }
        public virtual DbSet<Aluguel_Config> Aluguel_Config { get; set; }
        public virtual DbSet<Aluguel_Midia> Aluguel_Midia { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Midia> Midia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluguel>()
                .HasMany(e => e.Aluguel_Midia)
                .WithRequired(e => e.Aluguel)
                .HasForeignKey(e => e.ID_Aluguel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nome)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.CPF)
                .IsFixedLength();

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Aluguel)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.ID_Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Midia>()
                .Property(e => e.Titulo)
                .IsFixedLength();

            modelBuilder.Entity<Midia>()
                .HasMany(e => e.Aluguel_Midia)
                .WithRequired(e => e.Midia)
                .HasForeignKey(e => e.ID_Midia)
                .WillCascadeOnDelete(false);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using  Cliente.Domain.Entities;

namespace  Cliente.Migrations
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Operacao> Operacao { get; set; }
        public DbSet<Cessionario> Cessionario { get; set; }
        public DbSet<OperacaoCedente> OperacaoCedente { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }
        public DbSet<Banco> Banco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.DataRegistro).HasColumnName("data_registro");
                entity.Property(u => u.DataAlteracao).HasColumnName("data_alteracao");
            });

            modelBuilder.Entity<ContaCorrente>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Agencia).HasColumnName("agencia");
                entity.Property(c => c.AgenciaDigito).HasColumnName("agencia_digito");
                entity.Property(c => c.IdBanco).HasColumnName("id_banco");
                entity.Property(c => c.DataInativacao).HasColumnName("data_inativacao");
                entity.Property(c => c.DataRegistro).HasColumnName("data_registro");
                entity.Property(c => c.DataAlteracao).HasColumnName("data_alteracao");
            });

            modelBuilder.Entity<Operacao>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.DataRegistro).HasColumnName("data_registro");
                entity.Property(o => o.DataAlteracao).HasColumnName("data_alteracao");
            });

            modelBuilder.Entity<Cessionario>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.DataRegistro).HasColumnName("data_registro");
                entity.Property(c => c.DataAlteracao).HasColumnName("data_alteracao");
            });

            modelBuilder.Entity<OperacaoCedente>(entity =>
            {
                entity.HasKey(oc => oc.Id);
                entity.Property(oc => oc.DataRegistro).HasColumnName("data_registro");
                entity.Property(oc => oc.DataAlteracao).HasColumnName("data_alteracao");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DataRegistro).HasColumnName("data_registro");
                entity.Property(e => e.DataAlteracao).HasColumnName("data_alteracao");
            });

            modelBuilder.Entity<UsuarioEmpresa>(entity =>
            {
                entity.HasKey(ue => ue.Id);
                entity.Property(ue => ue.DataRegistro).HasColumnName("data_registro");
                entity.Property(ue => ue.DataAlteracao).HasColumnName("data_alteracao");
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.DataRegistro).HasColumnName("data_registro");
                entity.Property(b => b.DataAlteracao).HasColumnName("data_alteracao");
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ReplaceService<IHistoryRepository, CustomHistoryRepository>();
        }
    }
}

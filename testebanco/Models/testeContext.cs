using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testebanco.Models
{
    public partial class testeContext : DbContext
    {
        public testeContext()
        {
        }

        public testeContext(DbContextOptions<testeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Tblarquivo> Tblarquivos { get; set; } = null!;
        public virtual DbSet<Tblbolsadedez> Tblbolsadedezs { get; set; } = null!;
        public virtual DbSet<Tblcaixainner> Tblcaixainners { get; set; } = null!;
        public virtual DbSet<Tblcaixaouter> Tblcaixaouters { get; set; } = null!;
        public virtual DbSet<Tblkit> Tblkits { get; set; } = null!;
        public virtual DbSet<Tblpallet> Tblpallets { get; set; } = null!;
        public virtual DbSet<Tblsituacao> Tblsituacaos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;database=teste;user=root;password=1234;persist security info=False;connect timeout=300", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Tblarquivo>(entity =>
            {
                entity.HasKey(e => e.IdArquivo)
                    .HasName("PRIMARY");

                entity.ToTable("tblarquivo");

                entity.HasIndex(e => e.IdSituacao, "fk_SituacaoArquivo");

                entity.Property(e => e.IdArquivo)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Arquivo");

                entity.Property(e => e.IdSituacao)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Situacao");

                entity.Property(e => e.NomeCliente)
                    .HasMaxLength(35)
                    .HasColumnName("Nome_Cliente");

                entity.Property(e => e.NumeroArquivo)
                    .HasMaxLength(35)
                    .HasColumnName("Numero_Arquivo");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Tblarquivos)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SituacaoArquivo");
            });

            modelBuilder.Entity<Tblbolsadedez>(entity =>
            {
                entity.HasKey(e => e.IdBolsaDeDez)
                    .HasName("PRIMARY");

                entity.ToTable("tblbolsadedez");

                entity.HasIndex(e => e.IdCaixaInner, "fk_CaixaInnerBolsaDeDez");

                entity.HasIndex(e => e.IdSituacao, "fk_SituacaoBolsaDeDez");

                entity.Property(e => e.IdBolsaDeDez)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Bolsa_De_Dez");

                entity.Property(e => e.IdCaixaInner)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Caixa_Inner");

                entity.Property(e => e.IdSituacao)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Situacao");

                entity.Property(e => e.QuantidaKit)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("Quantida_Kit");

                entity.HasOne(d => d.IdCaixaInnerNavigation)
                    .WithMany(p => p.Tblbolsadedezs)
                    .HasForeignKey(d => d.IdCaixaInner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CaixaInnerBolsaDeDez");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Tblbolsadedezs)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SituacaoBolsaDeDez");
            });

            modelBuilder.Entity<Tblcaixainner>(entity =>
            {
                entity.HasKey(e => e.IdCaixaInner)
                    .HasName("PRIMARY");

                entity.ToTable("tblcaixainner");

                entity.HasIndex(e => e.IdCaixaOuter, "fk_CaixaOuterCaixaInner");

                entity.HasIndex(e => e.IdSituacao, "fk_SituacaoCaixaInner");

                entity.Property(e => e.IdCaixaInner)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Caixa_Inner");

                entity.Property(e => e.IdCaixaOuter)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Caixa_Outer");

                entity.Property(e => e.IdSituacao)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Situacao");

                entity.Property(e => e.QuantidaBolsaDeDez)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("Quantida_Bolsa_De_Dez");

                entity.HasOne(d => d.IdCaixaOuterNavigation)
                    .WithMany(p => p.Tblcaixainners)
                    .HasForeignKey(d => d.IdCaixaOuter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CaixaOuterCaixaInner");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Tblcaixainners)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SituacaoCaixaInner");
            });

            modelBuilder.Entity<Tblcaixaouter>(entity =>
            {
                entity.HasKey(e => e.IdCaixaOuter)
                    .HasName("PRIMARY");

                entity.ToTable("tblcaixaouter");

                entity.HasIndex(e => e.IdPallet, "fk_PalletCaixaOuter");

                entity.HasIndex(e => e.IdSituacao, "fk_SituacaoCaixaOuter");

                entity.Property(e => e.IdCaixaOuter)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Caixa_Outer");

                entity.Property(e => e.IdPallet)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Pallet");

                entity.Property(e => e.IdSituacao)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Situacao");

                entity.Property(e => e.QuantidaCaixaInner)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("Quantida_Caixa_Inner");

                entity.HasOne(d => d.IdPalletNavigation)
                    .WithMany(p => p.Tblcaixaouters)
                    .HasForeignKey(d => d.IdPallet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PalletCaixaOuter");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Tblcaixaouters)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SituacaoCaixaOuter");
            });

            modelBuilder.Entity<Tblkit>(entity =>
            {
                entity.HasKey(e => e.IdKit)
                    .HasName("PRIMARY");

                entity.ToTable("tblkit");

                entity.HasIndex(e => e.IdArquivo, "fk_ArquivoKit");

                entity.HasIndex(e => e.IdBolsaDeDez, "fk_BolsaDeDezKit");

                entity.HasIndex(e => e.IdCaixaInner, "fk_CaixaInnerKit");

                entity.HasIndex(e => e.IdCaixaOuter, "fk_CaixaOuterKit");

                entity.HasIndex(e => e.IdPallet, "fk_PalletKit");

                entity.HasIndex(e => e.IdSituacao, "fk_SituacaoKit");

                entity.Property(e => e.IdKit)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Kit");

                entity.Property(e => e.Iccid).HasMaxLength(35);

                entity.Property(e => e.IdArquivo)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Arquivo");

                entity.Property(e => e.IdBolsaDeDez)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Bolsa_De_Dez");

                entity.Property(e => e.IdCaixaInner)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Caixa_Inner");

                entity.Property(e => e.IdCaixaOuter)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Caixa_Outer");

                entity.Property(e => e.IdPallet)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Pallet");

                entity.Property(e => e.IdSituacao)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Situacao");

                entity.HasOne(d => d.IdArquivoNavigation)
                    .WithMany(p => p.Tblkits)
                    .HasForeignKey(d => d.IdArquivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ArquivoKit");

                entity.HasOne(d => d.IdBolsaDeDezNavigation)
                    .WithMany(p => p.Tblkits)
                    .HasForeignKey(d => d.IdBolsaDeDez)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BolsaDeDezKit");

                entity.HasOne(d => d.IdCaixaInnerNavigation)
                    .WithMany(p => p.Tblkits)
                    .HasForeignKey(d => d.IdCaixaInner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CaixaInnerKit");

                entity.HasOne(d => d.IdCaixaOuterNavigation)
                    .WithMany(p => p.Tblkits)
                    .HasForeignKey(d => d.IdCaixaOuter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CaixaOuterKit");

                entity.HasOne(d => d.IdPalletNavigation)
                    .WithMany(p => p.Tblkits)
                    .HasForeignKey(d => d.IdPallet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PalletKit");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Tblkits)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SituacaoKit");
            });

            modelBuilder.Entity<Tblpallet>(entity =>
            {
                entity.HasKey(e => e.IdPallet)
                    .HasName("PRIMARY");

                entity.ToTable("tblpallet");

                entity.HasIndex(e => e.IdSituacao, "fk_SituacaoPallet");

                entity.Property(e => e.IdPallet)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Pallet");

                entity.Property(e => e.IdSituacao)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Situacao");

                entity.Property(e => e.QuantidaCaixaOuter)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("Quantida_Caixa_Outer");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Tblpallets)
                    .HasForeignKey(d => d.IdSituacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SituacaoPallet");
            });

            modelBuilder.Entity<Tblsituacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao)
                    .HasName("PRIMARY");

                entity.ToTable("tblsituacao");

                entity.Property(e => e.IdSituacao)
                    .HasColumnType("int(10) unsigned")
                    .HasColumnName("ID_Situacao");

                entity.Property(e => e.Situacao).HasMaxLength(35);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

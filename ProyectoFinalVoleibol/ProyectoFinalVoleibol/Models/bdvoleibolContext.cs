using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoFinalVoleibol.Models
{
    public partial class bdvoleibolContext : DbContext
    {
        public bdvoleibolContext()
        {
        }

        public bdvoleibolContext(DbContextOptions<bdvoleibolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Directortecnico> Directortecnico { get; set; }
        public virtual DbSet<Integrantes> Integrantes { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=04.93.167.23;user=sistem14_voleius;password=LRC123;database=sistem14_voleibol");
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=bdvoleibol");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.ToTable("administrador");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Clave).HasColumnType("int(11)");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasComment("root")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Directortecnico>(entity =>
            {
                entity.ToTable("directortecnico");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Clave).HasColumnType("int(11)");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Equipo)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.InternacionalesGanados).HasColumnType("int(11)");

                entity.Property(e => e.InternacionalesPerdidos).HasColumnType("int(11)");

                entity.Property(e => e.NacionalesGanados).HasColumnType("int(11)");

                entity.Property(e => e.NacionalesPerdidos).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Seleccion)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Integrantes>(entity =>
            {
                entity.ToTable("integrantes");

                entity.HasIndex(e => e.IdDt)
                    .HasName("fk_IdDt_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Bloqueo).HasColumnType("int(10)");

                entity.Property(e => e.Edad).HasColumnType("int(10)");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Fuerza).HasColumnType("int(10)");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdDt).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NumCamiseta)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Posicion)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Recepcion).HasColumnType("int(10)");

                entity.Property(e => e.Remate).HasColumnType("int(10)");

                entity.Property(e => e.Salto).HasColumnType("int(10)");

                entity.Property(e => e.Saque).HasColumnType("int(10)");

                entity.HasOne(d => d.IdDtNavigation)
                    .WithMany(p => p.Integrantes)
                    .HasForeignKey(d => d.IdDt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_IdDt");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activo)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Codigo).HasColumnType("int(11)");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnType("tinytext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NomUser)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

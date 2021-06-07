using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplicationCLASIFICADOS_BackEnd.Models
{
    public partial class ca_2Context : DbContext
    {
        public ca_2Context()
        {
        }

        public ca_2Context(DbContextOptions<ca_2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Anuncio> Anuncios { get; set; }
        public virtual DbSet<Correos> Correos { get; set; }
        public virtual DbSet<TipoAnuncio> TipoAnuncios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=saea98.com;Port=5433;Database=ca_2;Username=ca_2;Password=4i5r25u8ca2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C.UTF-8");

            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.HasKey(e => e.IdAnuncio)
                    .HasName("ANUNCIOS_pkey");

                entity.ToTable("ANUNCIOS");

                entity.Property(e => e.IdAnuncio).HasColumnName("ID_ANUNCIO");

                entity.Property(e => e.Imagen).HasColumnName("IMAGEN");

                entity.Property(e => e.Precio).HasColumnName("PRECIO");

                entity.Property(e => e.Tipo).HasColumnName("TIPO");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TITULO");
            });

            modelBuilder.Entity<Correos>(entity =>
            {
                entity.HasKey(e => e.IdCorreo)
                    .HasName("CORREO_pkey");

                entity.ToTable("CORREO");

                entity.Property(e => e.IdCorreo)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CORREO");

                entity.Property(e => e.Correo)
                    .HasColumnType("character varying")
                    .HasColumnName("CORREO");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(100)
                    .HasColumnName("MENSAJE");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<TipoAnuncio>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("TIPO_ANUNCIO_pkey");

                entity.ToTable("TIPO_ANUNCIO");

                entity.Property(e => e.IdTipo)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TIPO");

                entity.Property(e => e.TipoAnuncio1)
                    .HasColumnType("character varying")
                    .HasColumnName("TIPO_ANUNCIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

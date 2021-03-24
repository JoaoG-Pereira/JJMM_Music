using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JJMM_Music.Models
{
    public partial class BandasDBContext : DbContext
    {
        public BandasDBContext()
        {
        }

        public BandasDBContext(DbContextOptions<BandasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artista> Artista { get; set; }
        public virtual DbSet<Banda> Banda { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Ingresso> Ingresso { get; set; }
        public virtual DbSet<Musica> Musica { get; set; }
        public virtual DbSet<Show> Show { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-S0G7FGN\\SQLEXPRESS;Database=BandasDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.IdAlbum);

                entity.Property(e => e.IdAlbum).HasColumnName("id_album");

                entity.Property(e => e.Ano)
                    .HasColumnName("ano")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.IdBanda).HasColumnName("id_banda");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBandaNavigation)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.IdBanda)
                    .HasConstraintName("FK__Album__id_banda__5165187F");
            });

            modelBuilder.Entity<Artista>(entity =>
            {
                entity.HasKey(e => e.IdArtista);

                entity.Property(e => e.IdArtista).HasColumnName("id_artista");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.IdBanda).HasColumnName("id_banda");

                entity.Property(e => e.Idade).HasColumnName("idade");

                entity.Property(e => e.Instrumento)
                    .HasColumnName("instrumento")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasColumnName("pais")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBandaNavigation)
                    .WithMany(p => p.Artista)
                    .HasForeignKey(d => d.IdBanda)
                    .HasConstraintName("FK__Artista__id_band__4E88ABD4");
            });

            modelBuilder.Entity<Banda>(entity =>
            {
                entity.HasKey(e => e.IdBanda);

                entity.Property(e => e.IdBanda).HasColumnName("id_banda");

                entity.Property(e => e.IdGenero).HasColumnName("id_genero");

                entity.Property(e => e.NomeBanda)
                    .HasColumnName("nomeBanda")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Banda)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__Banda__id_genero__4BAC3F29");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero);

                entity.Property(e => e.IdGenero).HasColumnName("id_genero");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.NomeGenero)
                    .HasColumnName("nome_genero")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingresso>(entity =>
            {
                entity.HasKey(e => e.IdIngresso);

                entity.Property(e => e.IdIngresso).HasColumnName("id_ingresso");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.IdShow).HasColumnName("id_show");

                entity.Property(e => e.Setor)
                    .HasColumnName("setor")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdShowNavigation)
                    .WithMany(p => p.Ingresso)
                    .HasForeignKey(d => d.IdShow)
                    .HasConstraintName("FK__Ingresso__id_sho__5AEE82B9");
            });

            modelBuilder.Entity<Musica>(entity =>
            {
                entity.HasKey(e => e.IdMusica);

                entity.Property(e => e.IdMusica).HasColumnName("id_musica");

                entity.Property(e => e.Ano)
                    .HasColumnName("ano")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Duracao).HasColumnName("duracao");

                entity.Property(e => e.IdAlbum).HasColumnName("id_album");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlbumNavigation)
                    .WithMany(p => p.Musica)
                    .HasForeignKey(d => d.IdAlbum)
                    .HasConstraintName("FK__Musica__id_album__5441852A");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.HasKey(e => e.IdShow);

                entity.Property(e => e.IdShow).HasColumnName("id_show");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdBanda).HasColumnName("id_banda");

                entity.Property(e => e.Local)
                    .HasColumnName("local")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdBandaNavigation)
                    .WithMany(p => p.Show)
                    .HasForeignKey(d => d.IdBanda)
                    .HasConstraintName("FK__Show__id_banda__571DF1D5");
            });
        }
    }
}

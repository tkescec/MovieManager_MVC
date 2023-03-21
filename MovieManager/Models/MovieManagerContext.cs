using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MovieManager.Models
{
    public partial class MovieManagerContext : DbContext
    {
        public MovieManagerContext()
        {
        }

        public MovieManagerContext(DbContextOptions<MovieManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<ActorMovie> ActorMovies { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieImage> MovieImages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:codetome.database.windows.net,1433;Initial Catalog=MovieManager;Persist Security Info=False;User ID=codetome;Password=5Bmnn3$MGMzdzFX;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Idactor)
                    .HasName("PK__Actor__ADDF60A673A80AD7");

                entity.ToTable("Actor");

                entity.Property(e => e.Idactor).HasColumnName("IDActor");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<ActorMovie>(entity =>
            {
                entity.HasKey(e => e.IdactorMovie)
                    .HasName("PK__ActorMov__D842B03A00FADB89");

                entity.ToTable("ActorMovie");

                entity.Property(e => e.IdactorMovie).HasColumnName("IDActorMovie");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorMovies)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("FK__ActorMovi__Actor__33D4B598");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.ActorMovies)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__ActorMovi__Movie__34C8D9D1");
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.Iddirector)
                    .HasName("PK__Director__74AB0A5FD662086D");

                entity.ToTable("Director");

                entity.Property(e => e.Iddirector).HasColumnName("IDDirector");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Idmovie)
                    .HasName("PK__Movie__9A101AD6DD26EBE4");

                entity.ToTable("Movie");

                entity.Property(e => e.Idmovie).HasColumnName("IDMovie");

                entity.Property(e => e.DirectorId).HasColumnName("DirectorID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK__Movie__DirectorI__286302EC");

                entity.HasMany(a => a.ActorMovies).WithOne(a => a.Movie).IsRequired();
            });

            modelBuilder.Entity<MovieImage>(entity =>
            {
                entity.HasKey(e => e.IdmovieImage)
                    .HasName("PK__MovieIma__EBB55E74113CEAB0");

                entity.ToTable("MovieImage");

                entity.Property(e => e.IdmovieImage).HasColumnName("IDMovieImage");

                entity.Property(e => e.MovieId).HasColumnName("MovieID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieImages)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__MovieImag__Movie__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using Microsoft.EntityFrameworkCore;

namespace EF_Art.Models.DB;

public partial class ArtContext : DbContext
{
    public ArtContext()
    {
    }

    public ArtContext(DbContextOptions<ArtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Artwork> Artworks { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Museum> Museums { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=PAX;Initial Catalog=Art; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.IdArtist);

            entity.ToTable("Artist");

            entity.Property(e => e.IdArtist).HasColumnName("Id_Artist");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Artwork>(entity =>
        {
            entity.HasKey(e => e.IdArtwork);

            entity.ToTable("Artwork");

            entity.HasIndex(e => e.IdArtwork, "UQ__Artwork__B99D1B3CA874096C").IsUnique();

            entity.Property(e => e.IdArtwork).HasColumnName("Id_Artwork");
            entity.Property(e => e.IdArtist).HasColumnName("Id_Artist");
            entity.Property(e => e.IdCharacter).HasColumnName("Id_Character");
            entity.Property(e => e.IdMuseum).HasColumnName("Id_Museum");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdArtistNavigation).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.IdArtist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Artist");

            entity.HasOne(d => d.IdCharacterNavigation).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.IdCharacter)
                .HasConstraintName("FK_Character");

            entity.HasOne(d => d.IdMuseumNavigation).WithMany(p => p.Artworks)
                .HasForeignKey(d => d.IdMuseum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Museum");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.IdCharacter);

            entity.ToTable("Character");


            entity.Property(e => e.IdCharacter).HasColumnName("Id_Character");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Museum>(entity =>
        {
            entity.HasKey(e => e.IdMuseum);

            entity.ToTable("Museum")

            entity.Property(e => e.IdMuseum).HasColumnName("Id_Museum");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MuseumName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

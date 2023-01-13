using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HotelApi;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Spa> Spas { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Services> Servicess { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=vfvfktyf2002");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "adminpack")
            .HasPostgresExtension("pgagent", "pgagent");

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menu_pkey");

            entity.ToTable("menu");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });
        modelBuilder.Entity<Services>(entity =>
        {
            entity.HasKey(e => e.id_services).HasName("Services_pkey");

            entity.ToTable("Services");

            entity.Property(e => e.id_services)
                .ValueGeneratedNever()
                .HasColumnName("id_services");
            entity.Property(e => e.port).HasColumnName("port");
            entity.Property(e => e.name).HasColumnName("name");
            entity.Property(e => e.host).HasColumnName("host");
            entity.Property(e => e.entered).HasColumnName("entered");
        }

           );
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("order_pkey");

            entity.ToTable("order");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.SpaId).HasColumnName("spa_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            //entity.HasOne(d => d.Menu).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.MenuId)
            //    .HasConstraintName("order_menu_id_fkey");

            //entity.HasOne(d => d.Room).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.RoomId)
            //    .HasConstraintName("order_room_id_fkey");

            //entity.HasOne(d => d.Spa).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.SpaId)
            //    .HasConstraintName("order_spa_id_fkey");

            //entity.HasOne(d => d.User).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("order_user_id_fkey");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("room_pkey");

            entity.ToTable("room");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Spa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("spa_pkey");

            entity.ToTable("spa");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pkey");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

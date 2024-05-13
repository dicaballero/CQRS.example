using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dcaba.users.Models;

public partial class CQRSContext : DbContext
{
    public CQRSContext()
    {
    }

    public CQRSContext(DbContextOptions<CQRSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDTO> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-120NFLV\\SQLEXPRESS01;initial catalog=Test2024;trusted_connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.UsrName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("usrName");
            entity.Property(e => e.UsrPassword)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("usrPassword");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

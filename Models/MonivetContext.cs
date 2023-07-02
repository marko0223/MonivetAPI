using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MonivetAPI.Models;

public partial class MonivetContext : DbContext
{
    public MonivetContext()
    {
    }

    public MonivetContext(DbContextOptions<MonivetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDetalleVentum> TbDetalleVenta { get; set; }

    public virtual DbSet<TbDistrito> TbDistritos { get; set; }

    public virtual DbSet<TbLogin> TbLogins { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-MARKO\\SQLEXPRESS;Initial Catalog=MONIVET;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.CodCli).HasName("PK__TB_CLIEN__151FF482961D2035");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.CodCli)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CLI");
            entity.Property(e => e.CodDis)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_DIS");
            entity.Property(e => e.Contacto)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CONTACTO");
            entity.Property(e => e.DirCli)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIR_CLI");
            entity.Property(e => e.DniCli)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI_CLI");
            entity.Property(e => e.FecReg)
                .HasColumnType("date")
                .HasColumnName("FEC_REG");
            entity.Property(e => e.NomCli)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOM_CLI");
            entity.Property(e => e.TipCli)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TIP_CLI");
            entity.Property(e => e.TlfCli)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TLF_CLI");

            entity.HasOne(d => d.CodDisNavigation).WithMany(p => p.TbClientes)
                .HasForeignKey(d => d.CodDis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_CLIENT__COD_D__398D8EEE");
        });

        modelBuilder.Entity<TbDetalleVentum>(entity =>
        {
            entity.HasKey(e => e.NumVen).HasName("PK__TB_DETAL__D5632C001C2BB2B1");

            entity.ToTable("TB_DETALLE_VENTA");

            entity.Property(e => e.NumVen).HasColumnName("NUM_VEN");
            entity.Property(e => e.CanVen).HasColumnName("CAN_VEN");
            entity.Property(e => e.DesVen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_VEN");
            entity.Property(e => e.PreVen)
                .HasColumnType("money")
                .HasColumnName("PRE_VEN");
            entity.Property(e => e.TotalVen)
                .HasColumnType("money")
                .HasColumnName("TOTAL_VEN");
        });

        modelBuilder.Entity<TbDistrito>(entity =>
        {
            entity.HasKey(e => e.CodDis).HasName("PK__TB_DISTR__2B2C6E893893E9EA");

            entity.ToTable("TB_DISTRITO");

            entity.Property(e => e.CodDis)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_DIS");
            entity.Property(e => e.NomDis)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_DIS");
        });

        modelBuilder.Entity<TbLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TB_LOGIN__3214EC07779FFB3F");

            entity.ToTable("TB_LOGIN");

            entity.Property(e => e.Contra)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.CodPro).HasName("PK__TB_PRODU__28BE23B591B57799");

            entity.ToTable("TB_PRODUCTO");

            entity.Property(e => e.CodPro)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_PRO");
            entity.Property(e => e.DesPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_PRO");
            entity.Property(e => e.Importado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("IMPORTADO");
            entity.Property(e => e.LinPro)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("LIN_PRO");
            entity.Property(e => e.PrePro)
                .HasColumnType("money")
                .HasColumnName("PRE_PRO");
            entity.Property(e => e.StkAct).HasColumnName("STK_ACT");
            entity.Property(e => e.StkMin).HasColumnName("STK_MIN");
            entity.Property(e => e.UniMed)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UNI_MED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

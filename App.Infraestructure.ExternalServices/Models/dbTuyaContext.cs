using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace App.Infraestructure.ExternalServices.Models
{
    public partial class dbTuyaContext : DbContext
    {
        public dbTuyaContext()
        {
        }

        public dbTuyaContext(DbContextOptions<dbTuyaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblFacturacion> TblFacturacions { get; set; }
        public virtual DbSet<TblPedido> TblPedidos { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-1O3VHJQR; Database=dbTuya; User=sa; Password=sqlserver.123");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblFacturacion>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion);

                entity.ToTable("tblFacturacion");

                entity.Property(e => e.IdTransaccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FldCodigoRespuesta)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("fldCodigoRespuesta");

                entity.Property(e => e.FldCvc)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fldCvc");

                entity.Property(e => e.FldFechaExpiracion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fldFechaExpiracion");

                entity.Property(e => e.FldNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fldNombre");

                entity.Property(e => e.FldNumeroTarjeta)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("fldNumeroTarjeta");

                entity.Property(e => e.FldPedido)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("fldPedido");

                entity.Property(e => e.FldPrecioTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("fldPrecioTotal");
            });

            modelBuilder.Entity<TblPedido>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion);

                entity.ToTable("tblPedidos");

                entity.Property(e => e.IdTransaccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FldEstadoEnvio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fldEstadoEnvio");

                entity.Property(e => e.FldFechaEntrega)
                    .HasColumnType("date")
                    .HasColumnName("fldFechaEntrega");

                entity.Property(e => e.FldFechaOrden)
                    .HasColumnType("date")
                    .HasColumnName("fldFechaOrden");

                entity.Property(e => e.FldPedido)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("fldPedido");

                entity.Property(e => e.FldPrecioTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("fldPrecioTotal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

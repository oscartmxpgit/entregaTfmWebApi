using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eCartaBEPrj.Models
{
    public partial class BDeCarta : DbContext
    {
        public BDeCarta()
        {
        }

        public BDeCarta(DbContextOptions<BDeCarta> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Encargado> Encargados { get; set; }
        public virtual DbSet<EvaluacionEmpleado> EvaluacionEmpleados { get; set; }
        public virtual DbSet<Insumo> Insumos { get; set; }
        public virtual DbSet<Mesa> Mesas { get; set; }
        public virtual DbSet<Negocio> Negocios { get; set; }
        public virtual DbSet<OperacionesCaja> OperacionesCajas { get; set; }
        public virtual DbSet<Plato> Platos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database = eCarta; Integrated Security = False;Persist Security Info = False; User ID = ecartauser;Password =123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.ToTable("Empleado");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dni");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdNegocio).HasColumnName("idNegocio");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("pass");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdNegocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Negocio");
            });

            modelBuilder.Entity<Encargado>(entity =>
            {
                entity.HasKey(e => e.IdEncargado);

                entity.ToTable("Encargado");

                entity.Property(e => e.IdEncargado).HasColumnName("idEncargado");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .HasColumnName("correo");

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("dni");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pass)
                    .HasMaxLength(500)
                    .HasColumnName("pass");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<EvaluacionEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdEvaluacionEmpleado);

                entity.ToTable("EvaluacionEmpleado");

                entity.Property(e => e.IdEvaluacionEmpleado).HasColumnName("idEvaluacionEmpleado");

                entity.Property(e => e.Criterio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("criterio");

                entity.Property(e => e.Evaluacion).HasColumnName("evaluacion");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.EvaluacionEmpleados)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EvaluacionEmpleado_Empleado");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.EvaluacionEmpleados)
                    .HasForeignKey(d => d.IdNegocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EvaluacionEmpleado_Negocio");
            });

            modelBuilder.Entity<Insumo>(entity =>
            {
                entity.HasKey(e => e.IdInsumo);

                entity.ToTable("Insumo");

                entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.IdNegocio).HasColumnName("idNegocio");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.Insumos)
                    .HasForeignKey(d => d.IdNegocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Insumo_Negocio");
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.HasKey(e => e.IdMesa);

                entity.ToTable("Mesa");

                entity.Property(e => e.IdMesa).HasColumnName("idMesa");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(50)
                    .HasColumnName("comentario");

                entity.Property(e => e.EstadoPedido)
                    .HasMaxLength(50)
                    .HasColumnName("estadoPedido");

                entity.Property(e => e.IdNegocio).HasColumnName("idNegocio");

                entity.Property(e => e.NoMesa).HasColumnName("noMesa");

                entity.Property(e => e.Personas).HasColumnName("personas");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.Mesas)
                    .HasForeignKey(d => d.IdNegocio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mesa_Negocio");
            });

            modelBuilder.Entity<Negocio>(entity =>
            {
                entity.HasKey(e => e.IdNegocio);

                entity.ToTable("Negocio");

                entity.Property(e => e.IdNegocio).HasColumnName("idNegocio");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .HasColumnName("direccion");

                entity.Property(e => e.IdEncargado).HasColumnName("idEncargado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdEncargadoNavigation)
                    .WithMany(p => p.Negocios)
                    .HasForeignKey(d => d.IdEncargado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Negocio_Encargado");
            });

            modelBuilder.Entity<OperacionesCaja>(entity =>
            {
                entity.HasKey(e => e.IdOperacionesCaja);

                entity.ToTable("OperacionesCaja");

                entity.Property(e => e.IdOperacionesCaja).HasColumnName("idOperacionesCaja");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaHora");

                entity.Property(e => e.IdNegocio).HasColumnName("idNegocio");

                entity.Property(e => e.Importe).HasColumnName("importe");

                entity.Property(e => e.Operacion)
                    .HasMaxLength(250)
                    .HasColumnName("operacion");

                entity.Property(e => e.Producto)
                    .HasMaxLength(500)
                    .HasColumnName("producto");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.OperacionesCajas)
                    .HasForeignKey(d => d.IdNegocio)
                    .HasConstraintName("FK_OperacionesCaja_Negocio");
            });

            modelBuilder.Entity<Plato>(entity =>
            {
                entity.HasKey(e => e.IdPlato);

                entity.ToTable("Plato");

                entity.Property(e => e.IdPlato).HasColumnName("idPlato");

                entity.Property(e => e.IdNegocio).HasColumnName("idNegocio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdNegocioNavigation)
                    .WithMany(p => p.Platos)
                    .HasForeignKey(d => d.IdNegocio)
                    .HasConstraintName("FK_Plato_Negocio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

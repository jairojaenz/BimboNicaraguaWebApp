using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BimboNicaragua.Models
{
    public partial class PanPlusBimboContext : DbContext
    {
        public PanPlusBimboContext()
        {
        }

        public PanPlusBimboContext(DbContextOptions<PanPlusBimboContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camione> Camiones { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<CuentasPorCobrar> CuentasPorCobrars { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<DetalleEntrega> DetalleEntregas { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<DetalleRutum> DetalleRuta { get; set; } = null!;
        public virtual DbSet<DetalleTransaccionInventario> DetalleTransaccionInventarios { get; set; } = null!;
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<EntregaProducto> EntregaProductos { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<Municipio> Municipios { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Ruta> Rutas { get; set; } = null!;
        public virtual DbSet<TransaccionesInventario> TransaccionesInventarios { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7755T4M\\SQLEXPRESS;DataBase=PanPlusBimbo;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camione>(entity =>
            {
                entity.HasKey(e => e.CamionId)
                    .HasName("PK__Camiones__0B8A6045E8582CD0");

                entity.Property(e => e.CamionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Camion_ID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("Cliente_ID");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MunicipioId).HasColumnName("Municipio_ID");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Municipio)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.MunicipioId)
                    .HasConstraintName("FK__Clientes__Munici__5070F446");
            });

            modelBuilder.Entity<CuentasPorCobrar>(entity =>
            {
                entity.HasKey(e => e.CuentaId)
                    .HasName("PK__Cuentas___10E58735966CC222");

                entity.ToTable("Cuentas_Por_Cobrar");

                entity.Property(e => e.CuentaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Cuenta_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Vencimiento");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.CuentasPorCobrars)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Cuentas_P__Clien__7B5B524B");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.DepartamentoId)
                    .ValueGeneratedNever()
                    .HasColumnName("Departamento_ID");

                entity.Property(e => e.NombreDepartamento)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetalleEntrega>(entity =>
            {
                entity.ToTable("Detalle_Entrega");

                entity.Property(e => e.DetalleEntregaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Detalle_Entrega_ID");

                entity.Property(e => e.CantidadEntregada).HasColumnName("Cantidad_Entregada");

                entity.Property(e => e.EntregaId).HasColumnName("Entrega_ID");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

                entity.HasOne(d => d.Entrega)
                    .WithMany(p => p.DetalleEntregas)
                    .HasForeignKey(d => d.EntregaId)
                    .HasConstraintName("FK__Detalle_E__Entre__0A9D95DB");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleEntregas)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Detalle_E__Produ__0B91BA14");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.DetalleId)
                    .HasName("PK__Detalle___CECB427F18DC8975");

                entity.ToTable("Detalle_Pedido");

                entity.Property(e => e.DetalleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Detalle_ID");

                entity.Property(e => e.PedidoId).HasColumnName("Pedido_ID");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.PedidoId)
                    .HasConstraintName("FK__Detalle_P__Pedid__7E37BEF6");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Detalle_P__Produ__7F2BE32F");
            });

            modelBuilder.Entity<DetalleRutum>(entity =>
            {
                entity.HasKey(e => e.DetalleRutaId)
                    .HasName("PK__Detalle___2CA879642D09FAAC");

                entity.ToTable("Detalle_Ruta");

                entity.Property(e => e.DetalleRutaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Detalle_Ruta_ID");

                entity.Property(e => e.PedidoId).HasColumnName("Pedido_ID");

                entity.Property(e => e.RutaId).HasColumnName("Ruta_ID");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.DetalleRuta)
                    .HasForeignKey(d => d.PedidoId)
                    .HasConstraintName("FK__Detalle_R__Pedid__71D1E811");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.DetalleRuta)
                    .HasForeignKey(d => d.RutaId)
                    .HasConstraintName("FK__Detalle_R__Ruta___70DDC3D8");
            });

            modelBuilder.Entity<DetalleTransaccionInventario>(entity =>
            {
                entity.HasKey(e => e.DetalleTransaccionId)
                    .HasName("PK__Detalle___274E3B30877C4FE7");

                entity.ToTable("Detalle_Transaccion_Inventario");

                entity.Property(e => e.DetalleTransaccionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Detalle_Transaccion_ID");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

                entity.Property(e => e.TransaccionId).HasColumnName("Transaccion_ID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleTransaccionInventarios)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Detalle_T__Produ__75A278F5");

                entity.HasOne(d => d.Transaccion)
                    .WithMany(p => p.DetalleTransaccionInventarios)
                    .HasForeignKey(d => d.TransaccionId)
                    .HasConstraintName("FK__Detalle_T__Trans__74AE54BC");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.HasKey(e => e.DetalleId)
                    .HasName("PK__Detalle___CECB427FE506B82F");

                entity.ToTable("Detalle_Venta");

                entity.Property(e => e.DetalleId)
                    .ValueGeneratedNever()
                    .HasColumnName("Detalle_ID");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Precio_Unitario");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

                entity.Property(e => e.VentaId).HasColumnName("Venta_ID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Detalle_V__Produ__02FC7413");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.VentaId)
                    .HasConstraintName("FK__Detalle_V__Venta__02084FDA");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.EmpleadoId)
                    .ValueGeneratedNever()
                    .HasColumnName("Empleado_ID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaContratacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Contratacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<EntregaProducto>(entity =>
            {
                entity.HasKey(e => e.EntregaId)
                    .HasName("PK__Entrega___3A2B6A369CD95555");

                entity.ToTable("Entrega_Producto");

                entity.Property(e => e.EntregaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Entrega_ID");

                entity.Property(e => e.CantidadEntregada).HasColumnName("Cantidad_Entregada");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Entrega");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

                entity.Property(e => e.RutaId).HasColumnName("Ruta_ID");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.EntregaProductos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Entrega_P__Clien__05D8E0BE");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.EntregaProductos)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Entrega_P__Produ__06CD04F7");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.EntregaProductos)
                    .HasForeignKey(d => d.RutaId)
                    .HasConstraintName("FK__Entrega_P__Ruta___07C12930");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.FacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Factura_ID");

                entity.Property(e => e.FechaFactura)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Factura");

                entity.Property(e => e.TotalFactura)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Total_Factura");

                entity.Property(e => e.VentaId).HasColumnName("Venta_ID");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.VentaId)
                    .HasConstraintName("FK__Facturas__Venta___6B24EA82");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.ToTable("Inventario");

                entity.Property(e => e.InventarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("Inventario_ID");

                entity.Property(e => e.CantidadDisponible).HasColumnName("Cantidad_Disponible");

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Actualizacion");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Inventari__Produ__656C112C");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.MunicipioId)
                    .ValueGeneratedNever()
                    .HasColumnName("Municipio_ID");

                entity.Property(e => e.DepartamentoId).HasColumnName("Departamento_ID");

                entity.Property(e => e.NombreMunicipio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("FK__Municipio__Depar__4D94879B");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.PedidoId)
                    .ValueGeneratedNever()
                    .HasColumnName("Pedido_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPedido)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Pedido");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Pedidos__Cliente__628FA481");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("Producto_ID");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasKey(e => e.ProveedorId)
                    .HasName("PK__Proveedo__0790A3EB6B678C1C");

                entity.Property(e => e.ProveedorId)
                    .ValueGeneratedNever()
                    .HasColumnName("Proveedor_ID");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProveedor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.Property(e => e.RutaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Ruta_ID");

                entity.Property(e => e.CamionId).HasColumnName("Camion_ID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpleadoId).HasColumnName("Empleado_ID");

                entity.Property(e => e.FechaRuta)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Ruta");

                entity.Property(e => e.Horario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Camion)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.CamionId)
                    .HasConstraintName("FK__Rutas__Camion_ID__571DF1D5");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.EmpleadoId)
                    .HasConstraintName("FK__Rutas__Empleado___5629CD9C");
            });

            modelBuilder.Entity<TransaccionesInventario>(entity =>
            {
                entity.HasKey(e => e.TransaccionId)
                    .HasName("PK__Transacc__B90CEB2E6DA62A73");

                entity.ToTable("Transacciones_Inventario");

                entity.Property(e => e.TransaccionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Transaccion_ID");

                entity.Property(e => e.FechaTransaccion)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Transaccion");

                entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.TransaccionesInventarios)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK__Transacci__Produ__68487DD7");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.Property(e => e.VentaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Venta_ID");

                entity.Property(e => e.ClienteId).HasColumnName("Cliente_ID");

                entity.Property(e => e.FechaVenta)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Venta");

                entity.Property(e => e.MontoTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Monto_Total");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Ventas__Cliente___5FB337D6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

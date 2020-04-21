using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Contexto
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<Supervisor> Supervisor { get; set; }
        public virtual DbSet<Traza> Traza { get; set; }
        public virtual DbSet<UsuarioCargo> UsuarioCargo { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //optionsBuilder.UseSqlServer("Server=PO-4820-CJJW2\\SQLEXPRESS;Database=PRUEBA;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("CARGO");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parametros>(entity =>
            {
                entity.ToTable("PARAMETROS");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaCrea).HasColumnType("datetime");

                entity.Property(e => e.FechaModifica).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.ToTable("SUPERVISOR");

                entity.HasOne(d => d.UsuarioSupervisaNavigation)
                    .WithMany(p => p.SupervisorUsuarioSupervisaNavigation)
                    .HasForeignKey(d => d.UsuarioSupervisa)
                    .HasConstraintName("FK_SUPERVISOR_SUPERVISA");

                entity.HasOne(d => d.UsuarioSupervisadoNavigation)
                    .WithMany(p => p.SupervisorUsuarioSupervisadoNavigation)
                    .HasForeignKey(d => d.UsuarioSupervisado)
                    .HasConstraintName("FK_SUPERVISOR_SUPERVISADO");
            });

            modelBuilder.Entity<Traza>(entity =>
            {
                entity.ToTable("TRAZA");

                entity.Property(e => e.Archivo).IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.UsuarioCrea)
                    .WithMany(p => p.Traza)
                    .HasForeignKey(d => d.UsuarioCreaId)
                    .HasConstraintName("FK_TRAZA_USUARIOCREA");
            });

            modelBuilder.Entity<UsuarioCargo>(entity =>
            {
                entity.ToTable("USUARIO_CARGO");

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.UsuarioCargo)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioCargo_Cargo");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Identificacion);

                entity.ToTable("USUARIOS");

                entity.Property(e => e.Identificacion).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}

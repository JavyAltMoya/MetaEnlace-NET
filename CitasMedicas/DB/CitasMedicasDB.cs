using CitasMedicas.Models;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicas.BBDD
{
    public class CitasMedicasDB : DbContext
    {
        public DbSet<UserModel> Usuario {  get; set; }
        public DbSet<PacientModel> Paciente { get; set; }
        public DbSet<MedicModel> Medico { get; set; }
        public DbSet<AppoModel> Citas { get; set; }
        public DbSet<DiagModel> Diagnostico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo de las columnas de Usuario y la relación TPH (herencia) con Paciente y Medico
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.id);

            modelBuilder.Entity<PacientModel>()
                .HasBaseType<UserModel>();

            modelBuilder.Entity<MedicModel>()
                .HasBaseType<UserModel>();

            // Mapeo de las columnas de Paciente
            modelBuilder.Entity<PacientModel>()
                .Property(p => p.nss)
                .HasColumnName("NSS");

            modelBuilder.Entity<PacientModel>()
                .Property(p => p.numTarjeta)
                .HasColumnName("numTarjeta");

            modelBuilder.Entity<PacientModel>()
                .Property(p => p.telefono)
                .HasColumnName("telefono");

            modelBuilder.Entity<PacientModel>()
                .Property(p => p.direccion)
                .HasColumnName("direccion");

            // Mapeo de las columnas de Medico
            modelBuilder.Entity<MedicModel>()
                .Property(m => m.numColegiado)
                .HasColumnName("numColegiado");

            // Mapeo y relaciones de Citas
            modelBuilder.Entity<AppoModel>()
                .HasKey(a => a.id);

            modelBuilder.Entity<AppoModel>()
                .HasOne(a => a.paciente)
                .WithMany(p => p.citas)
                .HasForeignKey(a => a.paciente_id);

            modelBuilder.Entity<AppoModel>()
                .HasOne(a => a.medico)
                .WithMany(m => m.citas)
                .HasForeignKey(a => a.medico_id);

            // Mapeo y relacion de Diagnóstico
            modelBuilder.Entity<DiagModel>()
                .HasKey(d => d.id);

            modelBuilder.Entity<DiagModel>()
                .HasOne(d => d.cita)
                .WithOne(a => a.diagnostico)
                .HasForeignKey<DiagModel>(d => d.cita_id);

            modelBuilder.Entity<PacientModel>().HasData(
                    new PacientModel { id=-1, nombre="Pepe", apellidos= "López", usuario="PLopez", clave="1234", nss="123123123", numTarjeta="123321123", direccion="Mi casa", telefono="345345345"}
                );

            modelBuilder.Entity<MedicModel>().HasData(
                    new MedicModel { id=-2, nombre = "Mario", apellidos = "Pujante", usuario = "MPujante", clave = "1234", numColegiado="12345A" }
                );
        }
        public CitasMedicasDB(DbContextOptions<CitasMedicasDB> options) : base(options) { 
            
        }
    }
}

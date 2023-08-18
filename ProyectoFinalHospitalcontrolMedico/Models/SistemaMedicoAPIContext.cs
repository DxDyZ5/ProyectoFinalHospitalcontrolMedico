using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoFinalHospitalcontrolMedico.Models
{
    public partial class SistemaMedicoAPIContext : DbContext
    {
        public SistemaMedicoAPIContext()
        {
        }

        public SistemaMedicoAPIContext(DbContextOptions<SistemaMedicoAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alta> Altas { get; set; } = null!;
        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Habitacione> Habitaciones { get; set; } = null!;
        public virtual DbSet<Ingreso> Ingresos { get; set; } = null!;
        public virtual DbSet<Medico> Medicos { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=AppConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alta>(entity =>
            {
                entity.HasKey(e => e.IdAlta)
                    .HasName("PK__Altas__265A35ACC6FF97A7");

                entity.Property(e => e.FechaSalida).HasColumnType("date");

                entity.Property(e => e.MontoPagar).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdIngresoNavigation)
                    .WithMany(p => p.Alta)
                    .HasForeignKey(d => d.IdIngreso)
                    .HasConstraintName("FK_Altas_Ingresos");
            });

            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCita)
                    .HasName("PK__Citas__394B0202E7FC03E9");

                entity.Property(e => e.FechaCitaHora).HasColumnType("date");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK_Citas_Medicos");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK_Citas_Pacientes");
            });

            modelBuilder.Entity<Habitacione>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion)
                    .HasName("PK__Habitaci__8BBBF9019A997C91");

                entity.Property(e => e.PrecioPorDia).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Tipo).HasMaxLength(20);
            });

            modelBuilder.Entity<Ingreso>(entity =>
            {
                entity.HasKey(e => e.IdIngreso)
                    .HasName("PK__Ingresos__901EF2E318B54D51");

                entity.Property(e => e.FechaInicioInter).HasColumnType("date");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.IdHabitacion)
                    .HasConstraintName("FK_Ingresos_Habitaciones");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Ingresos)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK_Ingresos_Pacientes");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medicos__C326E652FF677221");

                entity.Property(e => e.Especialidad).HasMaxLength(30);

                entity.Property(e => e.Exequatur).HasMaxLength(20);

                entity.Property(e => e.NombreMed).HasMaxLength(40);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__C93DB49BEAF2BDF5");

                entity.Property(e => e.Cedula).HasMaxLength(15);

                entity.Property(e => e.NombrePac).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

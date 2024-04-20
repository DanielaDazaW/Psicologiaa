﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Psicologia.Context;

#nullable disable

namespace Psicologiaa.Migrations
{
    [DbContext(typeof(EntidadesDbContext))]
    [Migration("20240419040745_Terapeuta")]
    partial class Terapeuta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Psicologiaa.Model.DatosPersonales", b =>
                {
                    b.Property<int>("IdDatos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDatos"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDatos");

                    b.ToTable("datosPersonales");
                });

            modelBuilder.Entity("Psicologiaa.Model.Evaluacion", b =>
                {
                    b.Property<int>("IdEvaluacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEvaluacion"));

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<string>("Resultados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoEvaluacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEvaluacion");

                    b.ToTable("evaluacion");
                });

            modelBuilder.Entity("Psicologiaa.Model.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<int?>("DatosPersonalesIdDatos")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDatos")
                        .HasColumnType("int");

                    b.HasKey("IdPaciente");

                    b.HasIndex("DatosPersonalesIdDatos");

                    b.ToTable("paciente");
                });

            modelBuilder.Entity("Psicologiaa.Model.Sesion", b =>
                {
                    b.Property<int>("IdSesion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSesion"));

                    b.Property<int?>("EvaluacionIdEvaluacion")
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("date");

                    b.Property<DateOnly>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<int>("IdEvaluacion")
                        .HasColumnType("int");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PacienteIdPaciente")
                        .HasColumnType("int");

                    b.Property<DateTime>("TiempoSesion")
                        .HasColumnType("datetime2");

                    b.HasKey("IdSesion");

                    b.HasIndex("EvaluacionIdEvaluacion");

                    b.HasIndex("PacienteIdPaciente");

                    b.ToTable("sesion");
                });

            modelBuilder.Entity("Psicologiaa.Model.Terapeuta", b =>
                {
                    b.Property<int>("IdTerapeuta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTerapeuta"));

                    b.Property<int?>("DatosPersonalesIdDatos")
                        .HasColumnType("int");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDatos")
                        .HasColumnType("int");

                    b.HasKey("IdTerapeuta");

                    b.HasIndex("DatosPersonalesIdDatos");

                    b.ToTable("terapeuta");
                });

            modelBuilder.Entity("Psicologiaa.Model.Paciente", b =>
                {
                    b.HasOne("Psicologiaa.Model.DatosPersonales", "DatosPersonales")
                        .WithMany()
                        .HasForeignKey("DatosPersonalesIdDatos");

                    b.Navigation("DatosPersonales");
                });

            modelBuilder.Entity("Psicologiaa.Model.Sesion", b =>
                {
                    b.HasOne("Psicologiaa.Model.Evaluacion", "Evaluacion")
                        .WithMany()
                        .HasForeignKey("EvaluacionIdEvaluacion");

                    b.HasOne("Psicologiaa.Model.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteIdPaciente");

                    b.Navigation("Evaluacion");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("Psicologiaa.Model.Terapeuta", b =>
                {
                    b.HasOne("Psicologiaa.Model.DatosPersonales", "DatosPersonales")
                        .WithMany()
                        .HasForeignKey("DatosPersonalesIdDatos");

                    b.Navigation("DatosPersonales");
                });
#pragma warning restore 612, 618
        }
    }
}

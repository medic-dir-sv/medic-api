﻿// <auto-generated />
using System;
using Medic.API.Dependencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medic.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220703000046_UpdateSync")]
    partial class UpdateSync
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Medic.Domain.Entities.Appointments.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClinicId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean");

                    b.Property<int?>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Clinics.Center", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int?>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("LocationId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Common.BaseIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.Property<Guid>("RecoveryToken")
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Patient");

                    b.HasKey("Id");

                    b.ToTable("BaseIdentities");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseIdentity");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Common.Geolocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Latitude")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Geolocation");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Formation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Formation");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Medic.Domain.Entities.TimeMeasures.TimeInterval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("EndsAt")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("StartsAt")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.ToTable("TimeInterval");
                });

            modelBuilder.Entity("Medic.Domain.Entities.TimeMeasures.Workday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Day")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<string>("WorkingHours")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Workday");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Doctor", b =>
                {
                    b.HasBaseType("Medic.Domain.Entities.Common.BaseIdentity");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("integer");

                    b.Property<string>("Specialty")
                        .HasColumnType("text");

                    b.HasIndex("ScheduleId");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Patients.Patient", b =>
                {
                    b.HasBaseType("Medic.Domain.Entities.Common.BaseIdentity");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Appointments.Appointment", b =>
                {
                    b.HasOne("Medic.Domain.Entities.Clinics.Center", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("Medic.Domain.Entities.Doctors.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Medic.Domain.Entities.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("Clinic");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Clinics.Center", b =>
                {
                    b.HasOne("Medic.Domain.Entities.Doctors.Doctor", null)
                        .WithMany("Clinics")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Medic.Domain.Entities.Common.Geolocation", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Experience", b =>
                {
                    b.HasOne("Medic.Domain.Entities.Doctors.Doctor", null)
                        .WithMany("Experience")
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Formation", b =>
                {
                    b.HasOne("Medic.Domain.Entities.Doctors.Doctor", null)
                        .WithMany("Formation")
                        .HasForeignKey("DoctorId");
                });

            modelBuilder.Entity("Medic.Domain.Entities.TimeMeasures.Workday", b =>
                {
                    b.HasOne("Medic.Domain.Entities.Doctors.Schedule", null)
                        .WithMany("Availability")
                        .HasForeignKey("ScheduleId");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Doctor", b =>
                {
                    b.HasOne("Medic.Domain.Entities.Doctors.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Schedule", b =>
                {
                    b.Navigation("Availability");
                });

            modelBuilder.Entity("Medic.Domain.Entities.Doctors.Doctor", b =>
                {
                    b.Navigation("Clinics");

                    b.Navigation("Experience");

                    b.Navigation("Formation");
                });
#pragma warning restore 612, 618
        }
    }
}

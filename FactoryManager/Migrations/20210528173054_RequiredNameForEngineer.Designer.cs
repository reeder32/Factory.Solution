﻿// <auto-generated />
using FactoryManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FactoryManagerProject.Migrations
{
    [DbContext(typeof(FactoryManagerContext))]
    [Migration("20210528173054_RequiredNameForEngineer")]
    partial class RequiredNameForEngineer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FactoryManager.Models.Engineer", b =>
                {
                    b.Property<int>("EngineerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("EngineerId");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("FactoryManager.Models.EngineerMachine", b =>
                {
                    b.Property<int>("EngineerMachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EngineerId")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.HasKey("EngineerMachineId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("MachineId");

                    b.ToTable("EngineerMachines");
                });

            modelBuilder.Entity("FactoryManager.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ModelName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("FactoryManager.Models.EngineerMachine", b =>
                {
                    b.HasOne("FactoryManager.Models.Engineer", "Engineer")
                        .WithMany("EngineerMachines")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FactoryManager.Models.Machine", "Machine")
                        .WithMany("EngineerMachines")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engineer");

                    b.Navigation("Machine");
                });

            modelBuilder.Entity("FactoryManager.Models.Engineer", b =>
                {
                    b.Navigation("EngineerMachines");
                });

            modelBuilder.Entity("FactoryManager.Models.Machine", b =>
                {
                    b.Navigation("EngineerMachines");
                });
#pragma warning restore 612, 618
        }
    }
}

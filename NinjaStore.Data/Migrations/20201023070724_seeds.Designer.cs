﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NinjaStore.Data;

namespace NinjaStore.Data.Migrations
{
    [DbContext(typeof(NinjaStoreDbContext))]
    [Migration("20201023070724_seeds")]
    partial class seeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NinjaStore.Data.Models.Equipment", b =>
                {
                    b.Property<int>("EquipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("EquipmentId");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            EquipmentId = 1,
                            Agility = 40,
                            Category = 0,
                            Intelligence = 40,
                            Name = "Petje",
                            Strength = 30,
                            Value = 100
                        },
                        new
                        {
                            EquipmentId = 2,
                            Agility = 86,
                            Category = 3,
                            Intelligence = 34,
                            Name = "Broek",
                            Strength = 32,
                            Value = 150
                        },
                        new
                        {
                            EquipmentId = 3,
                            Agility = 18,
                            Category = 0,
                            Intelligence = 40,
                            Name = "Hoed",
                            Strength = 16,
                            Value = 200
                        },
                        new
                        {
                            EquipmentId = 4,
                            Agility = 10,
                            Category = 5,
                            Intelligence = 10,
                            Name = "Kettingkje",
                            Strength = 60,
                            Value = 50
                        },
                        new
                        {
                            EquipmentId = 5,
                            Agility = 49,
                            Category = 3,
                            Intelligence = 309,
                            Name = "Crocs",
                            Strength = 98,
                            Value = 100
                        },
                        new
                        {
                            EquipmentId = 6,
                            Agility = 56,
                            Category = 4,
                            Intelligence = 86,
                            Name = "Vuurring",
                            Strength = 453,
                            Value = 200
                        },
                        new
                        {
                            EquipmentId = 7,
                            Agility = 76,
                            Category = 2,
                            Intelligence = 122,
                            Name = "Schoenhand",
                            Strength = 80,
                            Value = 300
                        },
                        new
                        {
                            EquipmentId = 8,
                            Agility = 469,
                            Category = 1,
                            Intelligence = 67,
                            Name = "Shirt",
                            Strength = 76,
                            Value = 100
                        });
                });

            modelBuilder.Entity("NinjaStore.Data.Models.Ninja", b =>
                {
                    b.Property<int>("NinjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NinjaId");

                    b.ToTable("Ninjas");
                });

            modelBuilder.Entity("NinjaStore.Data.Models.NinjaEquipment", b =>
                {
                    b.Property<int>("NinjaId")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentId")
                        .HasColumnType("int");

                    b.HasKey("NinjaId", "EquipmentId");

                    b.HasIndex("EquipmentId");

                    b.ToTable("NinjaEquipment");
                });

            modelBuilder.Entity("NinjaStore.Data.Models.NinjaEquipment", b =>
                {
                    b.HasOne("NinjaStore.Data.Models.Equipment", "Equipment")
                        .WithMany("OnderdeelVan")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NinjaStore.Data.Models.Ninja", "Ninja")
                        .WithMany("Bevat")
                        .HasForeignKey("NinjaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

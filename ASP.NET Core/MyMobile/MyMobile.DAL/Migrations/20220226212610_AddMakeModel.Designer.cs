﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMobile.DAL.Data;

#nullable disable

namespace MyMobile.DAL.Migrations
{
    [DbContext(typeof(MyMobileContext))]
    [Migration("20220226212610_AddMakeModel")]
    partial class AddMakeModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("DefaultPriceBgn")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.Property<decimal>("UserPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ConditionId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId");

                    b.HasIndex("RegionId");

                    b.HasIndex("TownId");

                    b.ToTable("CarAds");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Лек автомобил"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Джип"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Бус"
                        });
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conditions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Употребяван"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Нов"
                        },
                        new
                        {
                            Id = 3,
                            Type = "За части"
                        });
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CourseToDefault")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseToDefault = 1m,
                            Name = "BGN"
                        },
                        new
                        {
                            Id = 2,
                            CourseToDefault = 1.95m,
                            Name = "EUR"
                        });
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Пловдив"
                        });
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Towns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Асеновград",
                            RegionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Садово",
                            RegionId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Карлово",
                            RegionId = 1
                        });
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarArgs.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Makes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mercedes-Benz"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Opel"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Jeep"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Nissan"
                        });
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarArgs.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MakeId = 1,
                            Name = "530"
                        },
                        new
                        {
                            Id = 2,
                            MakeId = 1,
                            Name = "528"
                        },
                        new
                        {
                            Id = 3,
                            MakeId = 2,
                            Name = "E 320"
                        },
                        new
                        {
                            Id = 4,
                            MakeId = 2,
                            Name = "C 180"
                        },
                        new
                        {
                            Id = 5,
                            MakeId = 3,
                            Name = "Vectra"
                        },
                        new
                        {
                            Id = 6,
                            MakeId = 4,
                            Name = "Grand Cherokee"
                        },
                        new
                        {
                            Id = 7,
                            MakeId = 5,
                            Name = "Patrol"
                        },
                        new
                        {
                            Id = 8,
                            MakeId = 5,
                            Name = "Terano"
                        });
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAd", b =>
                {
                    b.HasOne("MyMobile.DAL.Models.CarAd.CarAdArgs.Category", "Category")
                        .WithMany("CarAds")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMobile.DAL.Models.CarAd.CarAdArgs.Condition", "Condition")
                        .WithMany("CarAds")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMobile.DAL.Models.CarAd.CarAdArgs.Currency", "Currency")
                        .WithMany("CarAds")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMobile.DAL.Models.CarAd.CarArgs.Make", "Make")
                        .WithMany("CarAds")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyMobile.DAL.Models.CarAd.CarArgs.Model", "Model")
                        .WithMany("CarAds")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MyMobile.DAL.Models.CarAd.CarAdArgs.Region", "Region")
                        .WithMany("CarAds")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMobile.DAL.Models.CarAd.CarAdArgs.Town", "Town")
                        .WithMany("CarAds")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Condition");

                    b.Navigation("Currency");

                    b.Navigation("Make");

                    b.Navigation("Model");

                    b.Navigation("Region");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Town", b =>
                {
                    b.HasOne("MyMobile.DAL.Models.CarAd.CarAdArgs.Region", "Region")
                        .WithMany("Towns")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarArgs.Model", b =>
                {
                    b.HasOne("MyMobile.DAL.Models.CarAd.CarArgs.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Make");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Category", b =>
                {
                    b.Navigation("CarAds");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Condition", b =>
                {
                    b.Navigation("CarAds");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Currency", b =>
                {
                    b.Navigation("CarAds");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Region", b =>
                {
                    b.Navigation("CarAds");

                    b.Navigation("Towns");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarAdArgs.Town", b =>
                {
                    b.Navigation("CarAds");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarArgs.Make", b =>
                {
                    b.Navigation("CarAds");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("MyMobile.DAL.Models.CarAd.CarArgs.Model", b =>
                {
                    b.Navigation("CarAds");
                });
#pragma warning restore 612, 618
        }
    }
}

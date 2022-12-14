// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YG.Data.Models;

#nullable disable

namespace YG.Data.Migrations
{
    [DbContext(typeof(YGDataContext))]
    [Migration("20220928102127_YG3")]
    partial class YG3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("YG.Data.Models.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdRateAtk")
                        .HasColumnType("int");

                    b.Property<int>("AdRateDef")
                        .HasColumnType("int");

                    b.Property<int>("ApRateAtk")
                        .HasColumnType("int");

                    b.Property<int>("ApRateDef")
                        .HasColumnType("int");

                    b.Property<int>("AtkBase")
                        .HasColumnType("int");

                    b.Property<int>("DefBase")
                        .HasColumnType("int");

                    b.Property<int>("Intelligent")
                        .HasColumnType("int");

                    b.Property<string>("NameAttribute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpeedBase")
                        .HasColumnType("int");

                    b.Property<int>("StrengBase")
                        .HasColumnType("int");

                    b.Property<int>("Tenacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Attribute");
                });

            modelBuilder.Entity("YG.Data.Models.Monter", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Atk")
                        .HasColumnType("int");

                    b.Property<Guid>("AttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Def")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("AttributeId");

                    b.HasIndex("TypeId");

                    b.ToTable("Monter");
                });

            modelBuilder.Entity("YG.Data.Models.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdRateAtk")
                        .HasColumnType("int");

                    b.Property<int>("AdRateDef")
                        .HasColumnType("int");

                    b.Property<int>("ApRateAtk")
                        .HasColumnType("int");

                    b.Property<int>("ApRateDef")
                        .HasColumnType("int");

                    b.Property<int>("AtkBase")
                        .HasColumnType("int");

                    b.Property<int>("DefBase")
                        .HasColumnType("int");

                    b.Property<int>("Intelligent")
                        .HasColumnType("int");

                    b.Property<string>("NameType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpeedBase")
                        .HasColumnType("int");

                    b.Property<int>("StrengBase")
                        .HasColumnType("int");

                    b.Property<int>("Tenacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("YG.Data.Models.Monter", b =>
                {
                    b.HasOne("YG.Data.Models.Attribute", "Attribute")
                        .WithMany("Monter")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YG.Data.Models.Type", "Type")
                        .WithMany("Monter")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("YG.Data.Models.Attribute", b =>
                {
                    b.Navigation("Monter");
                });

            modelBuilder.Entity("YG.Data.Models.Type", b =>
                {
                    b.Navigation("Monter");
                });
#pragma warning restore 612, 618
        }
    }
}

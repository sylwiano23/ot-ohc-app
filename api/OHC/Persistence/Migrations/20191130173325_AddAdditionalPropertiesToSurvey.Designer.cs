﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(OhcDbContext))]
    [Migration("20191130173325_AddAdditionalPropertiesToSurvey")]
    partial class AddAdditionalPropertiesToSurvey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Factor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FactorID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FactorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factors");
                });

            modelBuilder.Entity("Domain.Entities.FactorPosition", b =>
                {
                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("FactorId")
                        .HasColumnType("int");

                    b.HasKey("PositionId", "FactorId");

                    b.HasIndex("FactorId");

                    b.ToTable("FactorPositions");
                });

            modelBuilder.Entity("Domain.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PositionID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Domain.Entities.Survey.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SurveyID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DengerousZoneE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DengerousZoneH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionSurveyMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceKind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exposure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("IdentificationSurveyMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntermediateZoneE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntermediateZoneH")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interpretation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSurveySuspend")
                        .HasColumnType("bit");

                    b.Property<string>("MarkedParameter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NextSurveyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Performer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiskZoneE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiskZoneH")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("Domain.Entities.FactorPosition", b =>
                {
                    b.HasOne("Domain.Entities.Factor", "Factor")
                        .WithMany("FactorPositions")
                        .HasForeignKey("FactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Position", "Position")
                        .WithMany("FactorPositions")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

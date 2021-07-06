﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Podium_Case_Study.Data.DbContext;

namespace Podium_Case_Study.Migrations
{
    [DbContext(typeof(MortgageAppContext))]
    [Migration("20210704233742_addInterestTypeLookup")]
    partial class addInterestTypeLookup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Podium_Case_Study.Data.Entities.Applicant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("Podium_Case_Study.Data.Entities.InterestRateType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterestRateTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InterestRateTypes");
                });

            modelBuilder.Entity("Podium_Case_Study.Data.Entities.MortgageProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("InterestRate")
                        .HasColumnType("float");

                    b.Property<int>("InterestRateTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Lender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LoanToValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InterestRateTypeId");

                    b.ToTable("MortgageProducts");
                });

            modelBuilder.Entity("Podium_Case_Study.Data.Entities.MortgageProduct", b =>
                {
                    b.HasOne("Podium_Case_Study.Data.Entities.InterestRateType", "InterestRateType")
                        .WithMany()
                        .HasForeignKey("InterestRateTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using ClaimsApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClaimsApi.Data.Migrations
{
    [DbContext(typeof(ClaimContext))]
    [Migration("20230611000002_Company_PK")]
    partial class Company_PK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClaimsApi.Data.Entities.Claim", b =>
                {
                    b.Property<string>("AssuredName")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Assured Name");

                    b.Property<DateTime?>("ClaimDate")
                        .HasColumnType("DATETIME");

                    b.Property<bool?>("Closed")
                        .HasColumnType("bit");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<decimal?>("IncurredLoss")
                        .HasColumnType("DECIMAL(15,2)")
                        .HasColumnName("Incurred Loss");

                    b.Property<string>("Ucr")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("UCR");

                    b.HasIndex("Ucr")
                        .IsUnique()
                        .HasFilter("[UCR] IS NOT NULL");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("ClaimsApi.Data.Entities.ClaimType", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.ToTable("ClaimType");
                });

            modelBuilder.Entity("ClaimsApi.Data.Entities.Company", b =>
                {
                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address1")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Address3")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Identity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Identity"));

                    b.Property<DateTime?>("InsuranceEndDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PostCode")
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.ToTable("Company");
                });
#pragma warning restore 612, 618
        }
    }
}

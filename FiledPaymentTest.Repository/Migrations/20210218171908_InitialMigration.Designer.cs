﻿// <auto-generated />
using System;
using FiledPaymentTest.Repository.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FiledPaymentTest.Repository.Migrations
{
    [DbContext(typeof(FPTDBContext))]
    [Migration("20210218171908_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("FiledPaymentTest.Core.Entities.PaymentProcess", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("varchar(3)");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tries")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PaymentProcesses");
                });
#pragma warning restore 612, 618
        }
    }
}

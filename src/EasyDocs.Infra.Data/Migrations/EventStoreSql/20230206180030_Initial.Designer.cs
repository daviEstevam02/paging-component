﻿// <auto-generated />
using System;
using EasyDocs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyDocs.Infra.Data.Migrations.EventStoreSql
{
    [DbContext(typeof(EventStoreSqlContext))]
    [Migration("20230206180030_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EasyDocs.Domain.Core.Events.StoredEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("AggregateId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Context");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("AppliedAt");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("AppliedBy");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("StoredEvent");
                });
#pragma warning restore 612, 618
        }
    }
}

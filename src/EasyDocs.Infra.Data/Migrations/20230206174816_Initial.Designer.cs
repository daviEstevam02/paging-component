﻿// <auto-generated />
using System;
using EasyDocs.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyDocs.Infra.Data.Migrations
{
    [DbContext(typeof(EasyDocsContext))]
    [Migration("20230206174816_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EasyDocs.Domain.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsHeadquarter")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("LicenseeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("LicenseeId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DocumentTypeId")
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("File")
                        .HasColumnType("longblob");

                    b.Property<Guid>("LicenseeId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("SpecificAccess")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("LicenseeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.DocumentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DocumentGroup")
                        .HasColumnType("int");

                    b.Property<Guid>("LicenseeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LicenseeId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.Licensee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Licensees");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DocumentGroup")
                        .HasColumnType("int");

                    b.Property<Guid>("LicenseeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserTypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LicenseeId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.UserDocument", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LicenseeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId", "DocumentId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("LicenseeId");

                    b.ToTable("UserDocuments");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ErpUserType")
                        .HasColumnType("int");

                    b.Property<Guid>("LicenseeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LicenseeId");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.Company", b =>
                {
                    b.HasOne("EasyDocs.Domain.Entities.Licensee", "Licensee")
                        .WithMany("Companies")
                        .HasForeignKey("LicenseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("City");

                            b1.Property<string>("Compliment")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Compliment");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Country");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Neighborhood");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("varchar(10)")
                                .HasColumnName("Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("varchar(2)")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Street");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.CNPJ", "Cnpj", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("varchar(14)")
                                .HasColumnName("Cnpj");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.FantasyName", "FantasyName", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("FantasyName");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.LegalName", "LegalName", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("varchar(200)")
                                .HasColumnName("LegalName");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Phone", "Contact", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("varchar(22)")
                                .HasColumnName("Contact");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Cnpj")
                        .IsRequired();

                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("FantasyName")
                        .IsRequired();

                    b.Navigation("LegalName")
                        .IsRequired();

                    b.Navigation("Licensee");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.Document", b =>
                {
                    b.HasOne("EasyDocs.Domain.Entities.Company", "Company")
                        .WithMany("Documents")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.DocumentType", "DocumentType")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.Licensee", "Licensee")
                        .WithMany("Documents")
                        .HasForeignKey("LicenseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<Guid>("DocumentId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Description");

                            b1.HasKey("DocumentId");

                            b1.ToTable("Documents");

                            b1.WithOwner()
                                .HasForeignKey("DocumentId");
                        });

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Source", "Source", b1 =>
                        {
                            b1.Property<Guid>("DocumentId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("varchar(250)")
                                .HasColumnName("Source");

                            b1.HasKey("DocumentId");

                            b1.ToTable("Documents");

                            b1.WithOwner()
                                .HasForeignKey("DocumentId");
                        });

                    b.Navigation("Company");

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("Licensee");

                    b.Navigation("Source")
                        .IsRequired();
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.DocumentType", b =>
                {
                    b.HasOne("EasyDocs.Domain.Entities.Company", "Company")
                        .WithMany("DocumentTypes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.Licensee", "Licensee")
                        .WithMany("DocumentTypes")
                        .HasForeignKey("LicenseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<Guid>("DocumentTypeId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Description");

                            b1.HasKey("DocumentTypeId");

                            b1.ToTable("DocumentTypes");

                            b1.WithOwner()
                                .HasForeignKey("DocumentTypeId");
                        });

                    b.Navigation("Company");

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Licensee");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.Licensee", b =>
                {
                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<Guid>("LicenseeId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Description");

                            b1.HasKey("LicenseeId");

                            b1.ToTable("Licensees");

                            b1.WithOwner()
                                .HasForeignKey("LicenseeId");
                        });

                    b.Navigation("Description")
                        .IsRequired();
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.User", b =>
                {
                    b.HasOne("EasyDocs.Domain.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.Licensee", "Licensee")
                        .WithMany("Users")
                        .HasForeignKey("LicenseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Email");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("PasswordTyped")
                                .IsRequired()
                                .HasColumnType("varchar(16)")
                                .HasColumnName("Password");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Username", "Username", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Nickname")
                                .IsRequired()
                                .HasColumnType("varchar(30)")
                                .HasColumnName("Username");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Company");

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Licensee");

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("UserType");

                    b.Navigation("Username")
                        .IsRequired();
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.UserDocument", b =>
                {
                    b.HasOne("EasyDocs.Domain.Entities.Company", "Company")
                        .WithMany("UserDocuments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.Document", "Document")
                        .WithMany("UserDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.Licensee", "Licensee")
                        .WithMany("UserDocuments")
                        .HasForeignKey("LicenseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.User", "User")
                        .WithMany("UserDocuments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Document");

                    b.Navigation("Licensee");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.UserType", b =>
                {
                    b.HasOne("EasyDocs.Domain.Entities.Company", "Company")
                        .WithMany("UserTypes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyDocs.Domain.Entities.Licensee", "Licensee")
                        .WithMany("UserTypes")
                        .HasForeignKey("LicenseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<Guid>("UserTypeId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Text")
                                .IsRequired()
                                .HasColumnType("varchar(150)")
                                .HasColumnName("Description");

                            b1.HasKey("UserTypeId");

                            b1.ToTable("UserTypes");

                            b1.WithOwner()
                                .HasForeignKey("UserTypeId");
                        });

                    b.OwnsOne("EasyDocs.Domain.ValueObjects.Role", "Roles", b1 =>
                        {
                            b1.Property<Guid>("UserTypeId")
                                .HasColumnType("char(36)");

                            b1.Property<bool>("CanDelete")
                                .HasColumnType("boolean")
                                .HasColumnName("CanDelete");

                            b1.Property<bool>("CanRead")
                                .HasColumnType("boolean")
                                .HasColumnName("CanRead");

                            b1.Property<bool>("CanUpdate")
                                .HasColumnType("boolean")
                                .HasColumnName("CanUpdate");

                            b1.Property<bool>("CanWrite")
                                .HasColumnType("boolean")
                                .HasColumnName("CanWrite");

                            b1.HasKey("UserTypeId");

                            b1.ToTable("UserTypes");

                            b1.WithOwner()
                                .HasForeignKey("UserTypeId");
                        });

                    b.Navigation("Company");

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Licensee");

                    b.Navigation("Roles")
                        .IsRequired();
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.Company", b =>
                {
                    b.Navigation("DocumentTypes");

                    b.Navigation("Documents");

                    b.Navigation("UserDocuments");

                    b.Navigation("UserTypes");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.Document", b =>
                {
                    b.Navigation("UserDocuments");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.DocumentType", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.Licensee", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("DocumentTypes");

                    b.Navigation("Documents");

                    b.Navigation("UserDocuments");

                    b.Navigation("UserTypes");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.User", b =>
                {
                    b.Navigation("UserDocuments");
                });

            modelBuilder.Entity("EasyDocs.Domain.Entities.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

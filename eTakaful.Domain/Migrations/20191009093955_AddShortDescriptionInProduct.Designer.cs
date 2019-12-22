﻿// <auto-generated />
using System;
using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecommerce.Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191009093955_AddShortDescriptionInProduct")]
    partial class AddShortDescriptionInProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecommerce.Domain.Models.Nomination", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("NomineeFK");

                    b.Property<int>("Order");

                    b.Property<double>("PayoutPercentage");

                    b.Property<Guid>("PolicyFK");

                    b.Property<string>("RelationshipType")
                        .IsRequired();

                    b.Property<string>("Status")
                        .IsRequired();

                    b.Property<string>("UpdatedBy")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("NomineeFK");

                    b.HasIndex("PolicyFK");

                    b.ToTable("Nomination");
                });

            modelBuilder.Entity("Ecommerce.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalPhoneNo");

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("HadMajorSurgery");

                    b.Property<string>("Height");

                    b.Property<string>("IdentificationNo")
                        .IsRequired();

                    b.Property<string>("IdentificationType")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("MaritalStatus");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("NumberOfChildren");

                    b.Property<string>("Occupation");

                    b.Property<string>("PreExistingConditions");

                    b.Property<string>("PrimaryPhoneNo")
                        .IsRequired();

                    b.Property<string>("Sex")
                        .IsRequired();

                    b.Property<string>("UpdatedBy")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Ecommerce.Domain.Models.Policy", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("OwnerFK");

                    b.Property<Guid>("PlanFK");

                    b.Property<string>("PolicyNo")
                        .IsRequired();

                    b.Property<Guid>("SpouseFK");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("OwnerFK");

                    b.HasIndex("PlanFK");

                    b.HasIndex("SpouseFK");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("Ecommerce.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("UpdatedBy")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ecommerce.Domain.Models.TakafulPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CoverageAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PaymentFrequency")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status");

                    b.Property<string>("UpdatedBy")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("TakafulPlan");
                });

            modelBuilder.Entity("Ecommerce.Domain.Models.Nomination", b =>
                {
                    b.HasOne("Ecommerce.Domain.Models.Policy")
                        .WithMany("Nominations")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ecommerce.Domain.Models.Person", "Nominee")
                        .WithMany()
                        .HasForeignKey("NomineeFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ecommerce.Domain.Models.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ecommerce.Domain.Models.Policy", b =>
                {
                    b.HasOne("Ecommerce.Domain.Models.TakafulPlan")
                        .WithMany("Policies")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ecommerce.Domain.Models.Person", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ecommerce.Domain.Models.TakafulPlan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ecommerce.Domain.Models.Person", "Spouse")
                        .WithMany()
                        .HasForeignKey("SpouseFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
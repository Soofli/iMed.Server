﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using iMed.Repos.Models;

#nullable disable

namespace iMed.Repos.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220417124625_editUser")]
    partial class editUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("iMed.Domain.Entities.BaseRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("iMed.Domain.Entities.BaseUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseUser");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CourseCategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<bool>("IsFree")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSuggested")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("Reference")
                        .HasColumnType("text");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RemovedBy")
                        .HasColumnType("text");

                    b.Property<string>("Teacher")
                        .HasColumnType("text");

                    b.HasKey("CourseId");

                    b.HasIndex("CourseCategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CourseCategory", b =>
                {
                    b.Property<int>("CourseCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseCategoryId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RemovedBy")
                        .HasColumnType("text");

                    b.HasKey("CourseCategoryId");

                    b.ToTable("CourseCategories");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Handout", b =>
                {
                    b.Property<int>("HandoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HandoutId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Detail")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileLocation")
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RemovedBy")
                        .HasColumnType("text");

                    b.HasKey("HandoutId");

                    b.ToTable("Handouts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Handout");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImageId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileLocation")
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RemovedBy")
                        .HasColumnType("text");

                    b.HasKey("ImageId");

                    b.ToTable("Images");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Image");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentId"));

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("CardNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("PaymentTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RemovedBy")
                        .HasColumnType("text");

                    b.Property<string>("TransactionCode")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PurchaseId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsFree")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RemovedBy")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PurchaseId");

                    b.ToTable("Purchases");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Purchase");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RateId"));

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("RateMessage")
                        .HasColumnType("text");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RemovedBy")
                        .HasColumnType("text");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("RateId");

                    b.ToTable("Rates");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Rate");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Video", b =>
                {
                    b.Property<int>("VideoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VideoId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("FileLocation")
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<bool>("IsFree")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("RemovedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RemovedBy")
                        .HasColumnType("text");

                    b.Property<double>("VideoTime")
                        .HasColumnType("double precision");

                    b.HasKey("VideoId");

                    b.HasIndex("CourseId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("iMed.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.BaseUser");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CourseHandout", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.Handout");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.HasIndex("CourseId");

                    b.HasDiscriminator().HasValue("CourseHandout");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CourseImage", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.Image");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("CourseImage");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CoursePurchase", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.Purchase");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("CoursePurchase");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CourseRate", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.Rate");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.HasIndex("CourseId");

                    b.HasDiscriminator().HasValue("CourseRate");
                });

            modelBuilder.Entity("iMed.Domain.Entities.HandoutPurchase", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.Purchase");

                    b.Property<int>("HandoutId")
                        .HasColumnType("integer");

                    b.Property<int?>("SingleHandoutHandoutId")
                        .HasColumnType("integer");

                    b.HasIndex("HandoutId");

                    b.HasIndex("SingleHandoutHandoutId");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("HandoutPurchase");
                });

            modelBuilder.Entity("iMed.Domain.Entities.SingleHandout", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.Handout");

                    b.HasDiscriminator().HasValue("SingleHandout");
                });

            modelBuilder.Entity("iMed.Domain.Entities.User", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.BaseUser");

                    b.Property<string>("IdentityCode")
                        .HasColumnType("text");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("StudentCode")
                        .HasColumnType("text");

                    b.Property<long>("WalletBalance")
                        .HasColumnType("bigint");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("iMed.Domain.Entities.UserIdentityImage", b =>
                {
                    b.HasBaseType("iMed.Domain.Entities.Image");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("UserIdentityImage");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Course", b =>
                {
                    b.HasOne("iMed.Domain.Entities.CourseCategory", "CourseCategory")
                        .WithMany("Courses")
                        .HasForeignKey("CourseCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CourseCategory");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Payment", b =>
                {
                    b.HasOne("iMed.Domain.Entities.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Video", b =>
                {
                    b.HasOne("iMed.Domain.Entities.Course", "Course")
                        .WithMany("Videos")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("iMed.Domain.Entities.BaseRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("iMed.Domain.Entities.BaseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("iMed.Domain.Entities.BaseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("iMed.Domain.Entities.BaseRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("iMed.Domain.Entities.BaseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("iMed.Domain.Entities.BaseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("iMed.Domain.Entities.CourseHandout", b =>
                {
                    b.HasOne("iMed.Domain.Entities.Course", "Course")
                        .WithMany("Handouts")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CourseImage", b =>
                {
                    b.HasOne("iMed.Domain.Entities.Course", "Course")
                        .WithOne("Image")
                        .HasForeignKey("iMed.Domain.Entities.CourseImage", "CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CoursePurchase", b =>
                {
                    b.HasOne("iMed.Domain.Entities.Course", "Course")
                        .WithMany("CoursePurchases")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("iMed.Domain.Entities.User", "User")
                        .WithMany("VideoPurchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CourseRate", b =>
                {
                    b.HasOne("iMed.Domain.Entities.Course", "Course")
                        .WithMany("CourseRates")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("iMed.Domain.Entities.HandoutPurchase", b =>
                {
                    b.HasOne("iMed.Domain.Entities.Handout", "Handout")
                        .WithMany()
                        .HasForeignKey("HandoutId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("iMed.Domain.Entities.SingleHandout", null)
                        .WithMany("HandoutPurchases")
                        .HasForeignKey("SingleHandoutHandoutId");

                    b.HasOne("iMed.Domain.Entities.User", "User")
                        .WithMany("HandoutPurchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Handout");

                    b.Navigation("User");
                });

            modelBuilder.Entity("iMed.Domain.Entities.UserIdentityImage", b =>
                {
                    b.HasOne("iMed.Domain.Entities.User", "User")
                        .WithOne("UserIdentityImage")
                        .HasForeignKey("iMed.Domain.Entities.UserIdentityImage", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("iMed.Domain.Entities.Course", b =>
                {
                    b.Navigation("CoursePurchases");

                    b.Navigation("CourseRates");

                    b.Navigation("Handouts");

                    b.Navigation("Image");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("iMed.Domain.Entities.CourseCategory", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("iMed.Domain.Entities.SingleHandout", b =>
                {
                    b.Navigation("HandoutPurchases");
                });

            modelBuilder.Entity("iMed.Domain.Entities.User", b =>
                {
                    b.Navigation("HandoutPurchases");

                    b.Navigation("Payments");

                    b.Navigation("UserIdentityImage");

                    b.Navigation("VideoPurchases");
                });
#pragma warning restore 612, 618
        }
    }
}

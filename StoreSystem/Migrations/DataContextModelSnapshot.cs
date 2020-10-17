﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreSystem.Data;

namespace StoreSystem.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("StoreSystem.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("StoreSystem.Models.Item", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .HasColumnName("SubCategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PricePerUnit")
                        .HasColumnType("money");

                    b.Property<int?>("MinQty")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Qty")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubCategoryId", "PricePerUnit");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("StoreSystem.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SubCategory_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnName("Category_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("StoreSystem.Models.Item", b =>
                {
                    b.HasOne("StoreSystem.Models.SubCategory", "SubCategory")
                        .WithMany("Items")
                        .HasForeignKey("SubCategoryId")
                        .HasConstraintName("FK_Items_SubCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreSystem.Models.SubCategory", b =>
                {
                    b.HasOne("StoreSystem.Models.Category", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_SubCategory_Category1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

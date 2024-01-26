﻿// <auto-generated />
using System;
using BookNation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookNation.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240123143402_ProductAuthor")]
    partial class ProductAuthor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("BookNation.Entities.AppAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BuildingComplex")
                        .HasColumnType("TEXT");

                    b.Property<string>("CityTown")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceipientName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceipientNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suburb")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("AppAddress");
                });

            modelBuilder.Entity("BookNation.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("UserEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserPhone")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserSurname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookNation.Entities.ApplicableField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ApplicableFields");
                });

            modelBuilder.Entity("BookNation.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookNation.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("BookNation.Entities.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("BookNation.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookNation.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("BookNation.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BookNation.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Subtotal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("BookNation.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Barcode")
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Edition")
                        .HasColumnType("TEXT");

                    b.Property<string>("Format")
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PageCount")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("PublishedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Publisher")
                        .HasColumnType("TEXT");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Volume")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BookNation.Entities.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("BookNation.Entities.WishlistItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WishlistId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WishlistId");

                    b.ToTable("WishlistItem");
                });

            modelBuilder.Entity("BookNation.Entities.AppAddress", b =>
                {
                    b.HasOne("BookNation.Entities.AppUser", null)
                        .WithMany("Addresses")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.ApplicableField", b =>
                {
                    b.HasOne("BookNation.Entities.Product", null)
                        .WithMany("ApplicableField")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("BookNation.Entities.Author", b =>
                {
                    b.HasOne("BookNation.Entities.Product", null)
                        .WithMany("Author")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("BookNation.Entities.Cart", b =>
                {
                    b.HasOne("BookNation.Entities.AppUser", null)
                        .WithOne("Cart")
                        .HasForeignKey("BookNation.Entities.Cart", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.CartItem", b =>
                {
                    b.HasOne("BookNation.Entities.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.Invoice", b =>
                {
                    b.HasOne("BookNation.Entities.AppUser", null)
                        .WithMany("Invoices")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.Order", b =>
                {
                    b.HasOne("BookNation.Entities.AppUser", null)
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.OrderItem", b =>
                {
                    b.HasOne("BookNation.Entities.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.Product", b =>
                {
                    b.HasOne("BookNation.Entities.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.Wishlist", b =>
                {
                    b.HasOne("BookNation.Entities.AppUser", null)
                        .WithMany("Wishlists")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.WishlistItem", b =>
                {
                    b.HasOne("BookNation.Entities.Wishlist", null)
                        .WithMany("WishlistItems")
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookNation.Entities.AppUser", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cart");

                    b.Navigation("Invoices");

                    b.Navigation("Orders");

                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("BookNation.Entities.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("BookNation.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BookNation.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BookNation.Entities.Product", b =>
                {
                    b.Navigation("ApplicableField");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookNation.Entities.Wishlist", b =>
                {
                    b.Navigation("WishlistItems");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;

namespace Ecommerce.Migrations
{
    [DbContext(typeof(YourContext))]
    [Migration("20190125062601_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Ecommerce.Models.Bought", b =>
                {
                    b.Property<string>("boughtId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("itemId");

                    b.Property<int>("userId");

                    b.HasKey("boughtId");

                    b.HasIndex("itemId");

                    b.HasIndex("userId");

                    b.ToTable("boughtProds");
                });

            modelBuilder.Entity("Ecommerce.Models.CartItem", b =>
                {
                    b.Property<string>("CartItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CartId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("Quantity");

                    b.Property<int>("itemId");

                    b.HasKey("CartItemId");

                    b.HasIndex("itemId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Ecommerce.Models.Item", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("itemCategory")
                        .IsRequired();

                    b.Property<string>("itemDesc")
                        .IsRequired();

                    b.Property<string>("itemImage")
                        .IsRequired();

                    b.Property<string>("itemName")
                        .IsRequired();

                    b.Property<decimal>("itemPrice");

                    b.Property<int?>("userId");

                    b.HasKey("itemId");

                    b.HasIndex("userId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Ecommerce.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created_at");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("Updated_at");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ecommerce.Models.Bought", b =>
                {
                    b.HasOne("Ecommerce.Models.Item", "items")
                        .WithMany("boughts")
                        .HasForeignKey("itemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ecommerce.Models.User", "users")
                        .WithMany("boughts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ecommerce.Models.CartItem", b =>
                {
                    b.HasOne("Ecommerce.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("itemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ecommerce.Models.Item", b =>
                {
                    b.HasOne("Ecommerce.Models.User")
                        .WithMany("items")
                        .HasForeignKey("userId");
                });
#pragma warning restore 612, 618
        }
    }
}

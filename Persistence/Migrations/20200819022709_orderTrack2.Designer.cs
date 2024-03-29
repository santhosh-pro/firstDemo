﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using firstDemo.Persistence;

namespace firstDemo.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200819022709_orderTrack2")]
    partial class orderTrack2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("firstDemo.Common.AuditLog", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTime")
                        .HasColumnName("date_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("KeyValues")
                        .HasColumnName("key_values")
                        .HasColumnType("text");

                    b.Property<string>("NewValues")
                        .HasColumnName("new_values")
                        .HasColumnType("text");

                    b.Property<string>("OldValues")
                        .HasColumnName("old_values")
                        .HasColumnType("text");

                    b.Property<string>("TableName")
                        .HasColumnName("table_name")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_audit_log");

                    b.ToTable("audit_log","audit");
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnName("last_modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnName("last_modified_by")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("pk_category");

                    b.ToTable("category","product");
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnName("last_modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnName("last_modified_by")
                        .HasColumnType("text");

                    b.Property<long>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_number")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderStatusId")
                        .HasColumnName("order_status_id")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_order");

                    b.HasAlternateKey("OrderNumber")
                        .HasName("ak_order_order_number");

                    b.HasIndex("OrderStatusId")
                        .HasName("ix_order_order_status_id");

                    b.ToTable("order","order");
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.OrderItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnName("last_modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnName("last_modified_by")
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnName("order_id")
                        .HasColumnType("text");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnName("product_id")
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalPrice")
                        .HasColumnName("total_price")
                        .HasColumnType("double precision");

                    b.Property<double>("UnitPrice")
                        .HasColumnName("unit_price")
                        .HasColumnType("double precision");

                    b.HasKey("Id")
                        .HasName("pk_order_item");

                    b.HasIndex("OrderId")
                        .HasName("ix_order_item_order_id");

                    b.HasIndex("ProductId")
                        .HasName("ix_order_item_product_id");

                    b.ToTable("order_item","order");
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("pk_order_status");

                    b.ToTable("order_status","order");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Created"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Packing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Shipping"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delivered"
                        });
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.OrderTrack", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnName("last_modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnName("last_modified_by")
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnName("order_id")
                        .HasColumnType("text");

                    b.Property<int>("OrderStatusId")
                        .HasColumnName("order_status_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TrackingDate")
                        .HasColumnName("tracking_date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("pk_order_track");

                    b.HasIndex("OrderId")
                        .HasName("ix_order_track_order_id");

                    b.HasIndex("OrderStatusId")
                        .HasName("ix_order_track_order_status_id");

                    b.ToTable("order_track","order");
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("text");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnName("category_id")
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnName("last_modified_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnName("last_modified_by")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("double precision");

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.HasIndex("CategoryId")
                        .HasName("ix_product_category_id");

                    b.ToTable("product","product");
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.Order", b =>
                {
                    b.HasOne("firstDemo.Persistence.Entities.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .HasConstraintName("fk_order_order_status_order_status_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.OrderItem", b =>
                {
                    b.HasOne("firstDemo.Persistence.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_order_item_order_order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("firstDemo.Persistence.Entities.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_order_item_product_product_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.OrderTrack", b =>
                {
                    b.HasOne("firstDemo.Persistence.Entities.Order", "Order")
                        .WithMany("OrderTracks")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_order_track_order_order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("firstDemo.Persistence.Entities.OrderStatus", "OrderStatus")
                        .WithMany("OrderTracks")
                        .HasForeignKey("OrderStatusId")
                        .HasConstraintName("fk_order_track_order_status_order_status_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("firstDemo.Persistence.Entities.Product", b =>
                {
                    b.HasOne("firstDemo.Persistence.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_product_category_category_id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

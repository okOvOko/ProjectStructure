﻿// <auto-generated />
using BasicApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BasicApp.DataAccess.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    [Migration("20180630184846_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasicApp.DataAccess.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDone");

                    b.Property<int?>("ListId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("BasicApp.DataAccess.Model.ItemLabel", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<int>("LabelId");

                    b.HasKey("ItemId", "LabelId");

                    b.HasIndex("LabelId");

                    b.ToTable("ItemLabels");
                });

            modelBuilder.Entity("BasicApp.DataAccess.Model.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("BasicApp.DataAccess.Model.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("BasicApp.DataAccess.Model.Item", b =>
                {
                    b.HasOne("BasicApp.DataAccess.Model.List", "List")
                        .WithMany("Items")
                        .HasForeignKey("ListId");
                });

            modelBuilder.Entity("BasicApp.DataAccess.Model.ItemLabel", b =>
                {
                    b.HasOne("BasicApp.DataAccess.Model.Item", "Item")
                        .WithMany("IteamLabels")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BasicApp.DataAccess.Model.Label", "Label")
                        .WithMany("IteamLabels")
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
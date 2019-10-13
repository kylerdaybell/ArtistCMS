﻿// <auto-generated />
using System;
using KylerAndBrandonCMS2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KylerAndBrandonCMS2.Migrations
{
    [DbContext(typeof(CmsContext))]
    [Migration("20190416161013_kyler2.0")]
    partial class kyler20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("KylerAndBrandonCMS2.Models.ImageItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<int>("PageId");

                    b.Property<string>("Title");

                    b.Property<DateTime>("time");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("imageItems");
                });

            modelBuilder.Entity("KylerAndBrandonCMS2.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("KylerAndBrandonCMS2.Models.ParagraphItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("PageId");

                    b.Property<string>("Title");

                    b.Property<DateTime>("time");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("ParagraphItems");
                });

            modelBuilder.Entity("KylerAndBrandonCMS2.Models.ImageItem", b =>
                {
                    b.HasOne("KylerAndBrandonCMS2.Models.Page", "Page")
                        .WithMany("imageItems")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KylerAndBrandonCMS2.Models.ParagraphItem", b =>
                {
                    b.HasOne("KylerAndBrandonCMS2.Models.Page", "Page")
                        .WithMany("ParagraphItems")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

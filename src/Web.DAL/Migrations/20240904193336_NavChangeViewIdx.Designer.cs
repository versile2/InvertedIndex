﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.DAL.Data;

#nullable disable

namespace Web.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240904193336_NavChangeViewIdx")]
    partial class NavChangeViewIdx
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Web.DAL.Models.Data_NavLink", b =>
                {
                    b.Property<int>("NavLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Href")
                        .HasMaxLength(299)
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsNewWindow")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderById")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .HasMaxLength(299)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("NavLinkId");

                    b.HasIndex("ParentId");

                    b.ToTable("Data_NavLinks");

                    b.HasData(
                        new
                        {
                            NavLinkId = 1,
                            Href = " ",
                            Icon = "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M10 20v-6h4v6h5v-8h3L12 3 2 12h3v8z\"/>",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 0,
                            Title = "Home"
                        },
                        new
                        {
                            NavLinkId = 2,
                            Href = "",
                            Icon = "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M12 1L3 5v6c0 5.55 3.84 10.74 9 12 5.16-1.26 9-6.45 9-12V5l-9-4zm-2 16l-4-4 1.41-1.41L10 14.17l6.59-6.59L18 9l-8 8z\"/>",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 1,
                            Title = "Inverted Index"
                        },
                        new
                        {
                            NavLinkId = 3,
                            Href = "docupload",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 0,
                            ParentId = 2,
                            Title = "Upload Documents"
                        },
                        new
                        {
                            NavLinkId = 4,
                            Icon = "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M19 7v4H5.83l3.58-3.59L8 6l-6 6 6 6 1.41-1.41L5.83 13H21V7z\"/>",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 99,
                            Title = "Return to GitHub"
                        },
                        new
                        {
                            NavLinkId = 5,
                            Href = "https://github.com/karan/Projects",
                            IsActive = true,
                            IsNewWindow = true,
                            OrderById = 0,
                            ParentId = 4,
                            Title = "Mega Project List"
                        },
                        new
                        {
                            NavLinkId = 6,
                            Href = "https://github.com/karan/Projects-Solutions",
                            IsActive = true,
                            IsNewWindow = true,
                            OrderById = 1,
                            ParentId = 4,
                            Title = "Mega Solution List"
                        },
                        new
                        {
                            NavLinkId = 7,
                            Icon = "<g><rect fill=\"none\" height=\"24\" width=\"24\"/></g><g><g><path d=\"M17,11c0.34,0,0.67,0.04,1,0.09V6.27L10.5,3L3,6.27v4.91c0,4.54,3.2,8.79,7.5,9.82c0.55-0.13,1.08-0.32,1.6-0.55 C11.41,19.47,11,18.28,11,17C11,13.69,13.69,11,17,11z\"/><path d=\"M17,13c-2.21,0-4,1.79-4,4c0,2.21,1.79,4,4,4s4-1.79,4-4C21,14.79,19.21,13,17,13z M17,14.38c0.62,0,1.12,0.51,1.12,1.12 s-0.51,1.12-1.12,1.12s-1.12-0.51-1.12-1.12S16.38,14.38,17,14.38z M17,19.75c-0.93,0-1.74-0.46-2.24-1.17 c0.05-0.72,1.51-1.08,2.24-1.08s2.19,0.36,2.24,1.08C18.74,19.29,17.93,19.75,17,19.75z\"/></g></g>",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 98,
                            Role = "adminrole",
                            Title = "Admin"
                        },
                        new
                        {
                            NavLinkId = 8,
                            Href = "managenav",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 0,
                            ParentId = 7,
                            Role = "adminrole",
                            Title = "Navigation"
                        },
                        new
                        {
                            NavLinkId = 9,
                            Href = "docsearch",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 1,
                            ParentId = 2,
                            Title = "Search Documents"
                        },
                        new
                        {
                            NavLinkId = 10,
                            Href = "viewidx",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 2,
                            ParentId = 2,
                            Title = "View Index"
                        });
                });

            modelBuilder.Entity("Web.DAL.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("DocumentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Web.DAL.Models.Data_NavLink", b =>
                {
                    b.HasOne("Web.DAL.Models.Data_NavLink", "ParentNavLink")
                        .WithMany("ChildNavLinks")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentNavLink");
                });

            modelBuilder.Entity("Web.DAL.Models.Data_NavLink", b =>
                {
                    b.Navigation("ChildNavLinks");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.DAL.Data;

#nullable disable

namespace Web.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Web.DAL.Models.AppError", b =>
                {
                    b.Property<int>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ErrorStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoggedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(99)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("ErrorId");

                    b.HasIndex("ErrorStatusId");

                    b.ToTable("AppErrors");
                });

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
                        },
                        new
                        {
                            NavLinkId = 11,
                            Href = "viewerror",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 1,
                            ParentId = 7,
                            Title = "View Error Log"
                        },
                        new
                        {
                            NavLinkId = 32,
                            Icon = "<path d=\"M0 0h24v24H0z\" fill=\"none\"/><path d=\"M2 17h2v.5H3v1h1v.5H2v1h3v-4H2v1zm1-9h1V4H2v1h1v3zm-1 3h1.8L2 13.1v.9h3v-1H3.2L5 10.9V10H2v1zm5-6v2h14V5H7zm0 14h14v-2H7v2zm0-6h14v-2H7v2z\"/>",
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 97,
                            Title = "Hierarchy Nav"
                        },
                        new
                        {
                            NavLinkId = 33,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 1,
                            ParentId = 32,
                            Title = "Level 1"
                        },
                        new
                        {
                            NavLinkId = 34,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 2,
                            ParentId = 33,
                            Title = "Level 2"
                        },
                        new
                        {
                            NavLinkId = 35,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 3,
                            ParentId = 34,
                            Title = "Level 3"
                        },
                        new
                        {
                            NavLinkId = 36,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 4,
                            ParentId = 35,
                            Title = "Level 4"
                        },
                        new
                        {
                            NavLinkId = 37,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 5,
                            ParentId = 36,
                            Title = "Level 5"
                        },
                        new
                        {
                            NavLinkId = 38,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 6,
                            ParentId = 37,
                            Title = "Level 6"
                        },
                        new
                        {
                            NavLinkId = 39,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 7,
                            ParentId = 38,
                            Title = "Level 7"
                        },
                        new
                        {
                            NavLinkId = 40,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 8,
                            ParentId = 39,
                            Title = "Level 8"
                        },
                        new
                        {
                            NavLinkId = 41,
                            IsActive = true,
                            IsNewWindow = false,
                            OrderById = 9,
                            ParentId = 40,
                            Title = "Level 9"
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

            modelBuilder.Entity("Web.DAL.Models.ErrorStatus", b =>
                {
                    b.Property<int>("ErrorStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ErrorStatusText")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("ErrorStatusId");

                    b.ToTable("ErrorStatus");

                    b.HasData(
                        new
                        {
                            ErrorStatusId = 1,
                            ErrorStatusText = "New"
                        },
                        new
                        {
                            ErrorStatusId = 2,
                            ErrorStatusText = "Acknowledged"
                        },
                        new
                        {
                            ErrorStatusId = 3,
                            ErrorStatusText = "Resolved"
                        });
                });

            modelBuilder.Entity("Web.DAL.Models.AppError", b =>
                {
                    b.HasOne("Web.DAL.Models.ErrorStatus", "ErrorStatus")
                        .WithMany()
                        .HasForeignKey("ErrorStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ErrorStatus");
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

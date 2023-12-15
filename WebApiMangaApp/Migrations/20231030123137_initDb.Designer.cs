﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiMangaApp.Data;

#nullable disable

namespace WebApiMangaApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231030123137_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MangaList.Models.CategoryManga", b =>
                {
                    b.Property<int>("MangaId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("MangaId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryMangas");
                });

            modelBuilder.Entity("WebApiMangaApp.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebApiMangaApp.Model.Manga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mangas");
                });

            modelBuilder.Entity("MangaList.Models.CategoryManga", b =>
                {
                    b.HasOne("WebApiMangaApp.Model.Manga", "Manga")
                        .WithMany("CategoryMangas")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApiMangaApp.Model.Category", "Category")
                        .WithMany("CategoryMangas")
                        .HasForeignKey("MangaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manga");
                });

            modelBuilder.Entity("WebApiMangaApp.Model.Category", b =>
                {
                    b.Navigation("CategoryMangas");
                });

            modelBuilder.Entity("WebApiMangaApp.Model.Manga", b =>
                {
                    b.Navigation("CategoryMangas");
                });
#pragma warning restore 612, 618
        }
    }
}
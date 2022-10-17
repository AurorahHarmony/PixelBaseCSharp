﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PixelBase.Data;

#nullable disable

namespace PixelBase.Migrations
{
  [DbContext(typeof(PixelBaseContext))]
  partial class PixelBaseContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

      modelBuilder.Entity("PixelBase.Models.Asset", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("INTEGER");

            b.Property<string>("Title")
                      .HasColumnType("TEXT");

            b.HasKey("Id");

            b.ToTable("Asset");
          });
#pragma warning restore 612, 618
    }
  }
}

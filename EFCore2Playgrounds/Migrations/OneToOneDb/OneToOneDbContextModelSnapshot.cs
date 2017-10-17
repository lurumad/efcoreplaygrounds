﻿// <auto-generated />
using EFCore2Playgrounds.OneToOne;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EFCore2Playgrounds.Migrations.OneToOneDb
{
    [DbContext(typeof(OneToOneDbContext))]
    partial class OneToOneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore2Playgrounds.OneToOne.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("EFCore2Playgrounds.OneToOne.Biography", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("Biographies");
                });

            modelBuilder.Entity("EFCore2Playgrounds.OneToOne.Biography", b =>
                {
                    b.HasOne("EFCore2Playgrounds.OneToOne.Author")
                        .WithOne("Biography")
                        .HasForeignKey("EFCore2Playgrounds.OneToOne.Biography", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using ApiZakladokNet.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiZakladokNet.Migrations
{
    [DbContext(typeof(EFContext))]
    partial class EFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiZakladokNet.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoordX")
                        .IsRequired();

                    b.Property<string>("CoordY")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Imagge");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.Property<float>("Quantity");

                    b.Property<int>("User_Id");

                    b.HasKey("Id");

                    b.HasIndex("User_Id")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ApiZakladokNet.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ApiZakladokNet.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("Roles_Id");

                    b.HasKey("Id");

                    b.HasIndex("Roles_Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ApiZakladokNet.Entity.Product", b =>
                {
                    b.HasOne("ApiZakladokNet.Entity.User", "UserOf")
                        .WithOne("ProductOf")
                        .HasForeignKey("ApiZakladokNet.Entity.Product", "User_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiZakladokNet.Entity.User", b =>
                {
                    b.HasOne("ApiZakladokNet.Entity.Role", "RoleOf")
                        .WithMany("Users")
                        .HasForeignKey("Roles_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseCRUD.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20190528061631_createInitial")]
    partial class createInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cinsiyet", b =>
                {
                    b.Property<int>("cinsiyetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cinsiyetAdi")
                        .IsRequired();

                    b.HasKey("cinsiyetId");

                    b.ToTable("cinsiyetler");
                });

            modelBuilder.Entity("personel", b =>
                {
                    b.Property<int>("personelNo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ad")
                        .IsRequired();

                    b.Property<int>("cinsiyetId");

                    b.Property<string>("soyad")
                        .IsRequired();

                    b.HasKey("personelNo");

                    b.HasIndex("cinsiyetId");

                    b.ToTable("personeller");
                });

            modelBuilder.Entity("personel", b =>
                {
                    b.HasOne("cinsiyet", "cinsiyet")
                        .WithMany()
                        .HasForeignKey("cinsiyetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

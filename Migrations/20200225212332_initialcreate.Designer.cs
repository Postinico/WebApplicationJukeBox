﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationJukebox.Data;

namespace WebApplicationJukeBox.Migrations
{
    [DbContext(typeof(StoreDataContext))]
    [Migration("20200225212332_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplicationJukebox.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<int>("GeneroId");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("WebApplicationJukebox.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("WebApplicationJukebox.Models.nUsuarios.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Perfil_Usuario");
                });

            modelBuilder.Entity("WebApplicationJukebox.Models.nUsuarios.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<int>("PerfilId");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("WebApplicationJukebox.Models.Album", b =>
                {
                    b.HasOne("WebApplicationJukebox.Models.Genero", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplicationJukebox.Models.nUsuarios.Usuario", b =>
                {
                    b.HasOne("WebApplicationJukebox.Models.nUsuarios.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

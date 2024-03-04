﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodeTree.DAL.Contexts;

#nullable disable

namespace NodeTree.DAL.Migrations
{
    [DbContext(typeof(NodeTreeDBContext))]
    partial class NodeTreeDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("EventId");

            modelBuilder.Entity("NodeTree.DAL.Entities.JournalRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("NEXT VALUE FOR EventId");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JournalRecords");
                });

            modelBuilder.Entity("NodeTree.DAL.Entities.TreeNode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("ParentNodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentNodeId");

                    b.ToTable("TreeNodes");
                });

            modelBuilder.Entity("NodeTree.DAL.Entities.TreeNode", b =>
                {
                    b.HasOne("NodeTree.DAL.Entities.TreeNode", "ParentNode")
                        .WithMany("Children")
                        .HasForeignKey("ParentNodeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentNode");
                });

            modelBuilder.Entity("NodeTree.DAL.Entities.TreeNode", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}

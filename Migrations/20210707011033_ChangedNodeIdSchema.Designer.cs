﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteTree.Contexts;

namespace NoteTree.Migrations
{
    [DbContext(typeof(TreeDocumentContext))]
    [Migration("20210707011033_ChangedNodeIdSchema")]
    partial class ChangedNodeIdSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("NoteTree.Models.DocNode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("TEXT");

                    b.Property<long>("NodeId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ParentNodeId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TreeDocumentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("data")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TreeDocumentId");

                    b.ToTable("DocNode");
                });

            modelBuilder.Entity("NoteTree.Models.TreeDocument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TreeDocuments");
                });

            modelBuilder.Entity("NoteTree.Models.DocNode", b =>
                {
                    b.HasOne("NoteTree.Models.TreeDocument", null)
                        .WithMany("NodeList")
                        .HasForeignKey("TreeDocumentId");
                });

            modelBuilder.Entity("NoteTree.Models.TreeDocument", b =>
                {
                    b.Navigation("NodeList");
                });
#pragma warning restore 612, 618
        }
    }
}
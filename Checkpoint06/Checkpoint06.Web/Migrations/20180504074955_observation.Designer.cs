﻿// <auto-generated />
using Checkpoint06.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Checkpoint06.Migrations
{
    [DbContext(typeof(ObservationContext))]
    [Migration("20180504074955_observation")]
    partial class observation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Checkpoint06.Domain.Observation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.Property<string>("Notes");

                    b.Property<string>("Species");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("Observations");
                });
#pragma warning restore 612, 618
        }
    }
}

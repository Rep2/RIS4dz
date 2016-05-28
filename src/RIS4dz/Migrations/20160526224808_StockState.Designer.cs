using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using RIS4dz.Models;

namespace RIS4dz.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160526224808_StockState")]
    partial class StockState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RIS4dz.Models.Stock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("Value");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("RIS4dz.Models.StockState", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("StockID");

                    b.Property<double>("Value");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("RIS4dz.Models.StockState", b =>
                {
                    b.HasOne("RIS4dz.Models.Stock")
                        .WithMany()
                        .HasForeignKey("StockID");
                });
        }
    }
}

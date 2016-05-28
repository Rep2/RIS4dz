using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using RIS4dz.Models;

namespace RIS4dz.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RIS4dz.Models.Fund", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");
                });

            modelBuilder.Entity("RIS4dz.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOrdered");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<double>("ShareValueAtOrder");

                    b.Property<double>("TotalValueAtOrder");

                    b.Property<double>("TransactionFee");

                    b.Property<int>("numberOfShares");

                    b.HasKey("ID");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Order");
                });

            modelBuilder.Entity("RIS4dz.Models.Stock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasAlternateKey("Name");
                });

            modelBuilder.Entity("RIS4dz.Models.StockMultiplyer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FundID");

                    b.Property<double>("Multiplyer");

                    b.Property<int>("StockID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("RIS4dz.Models.StockState", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BuyRate");

                    b.Property<DateTime>("Date");

                    b.Property<double>("SellRate");

                    b.Property<int>("StockID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("RIS4dz.Models.FundOrder", b =>
                {
                    b.HasBaseType("RIS4dz.Models.Order");

                    b.Property<int>("FundID");

                    b.HasAnnotation("Relational:DiscriminatorValue", "FundOrder");
                });

            modelBuilder.Entity("RIS4dz.Models.StockOrder", b =>
                {
                    b.HasBaseType("RIS4dz.Models.Order");

                    b.Property<int>("StockID");

                    b.HasAnnotation("Relational:DiscriminatorValue", "StockOrder");
                });

            modelBuilder.Entity("RIS4dz.Models.StockMultiplyer", b =>
                {
                    b.HasOne("RIS4dz.Models.Fund")
                        .WithMany()
                        .HasForeignKey("FundID");

                    b.HasOne("RIS4dz.Models.Stock")
                        .WithMany()
                        .HasForeignKey("StockID");
                });

            modelBuilder.Entity("RIS4dz.Models.StockState", b =>
                {
                    b.HasOne("RIS4dz.Models.Stock")
                        .WithMany()
                        .HasForeignKey("StockID");
                });

            modelBuilder.Entity("RIS4dz.Models.FundOrder", b =>
                {
                    b.HasOne("RIS4dz.Models.Fund")
                        .WithMany()
                        .HasForeignKey("FundID");
                });

            modelBuilder.Entity("RIS4dz.Models.StockOrder", b =>
                {
                    b.HasOne("RIS4dz.Models.Stock")
                        .WithMany()
                        .HasForeignKey("StockID");
                });
        }
    }
}

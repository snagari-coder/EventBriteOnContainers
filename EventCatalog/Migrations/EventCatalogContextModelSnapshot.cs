﻿// <auto-generated />
using System;
using EventCatalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventCatalog.Migrations
{
    [DbContext(typeof(EventCatalogContext))]
    partial class EventCatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.Event_Audience_hilo", "'Event_Audience_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Event_Category_hilo", "'Event_Category_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Event_Format_hilo", "'Event_Format_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Event_Item_hilo", "'Event_Item_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Event_Kind_hilo", "'Event_Kind_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Event_Language_hilo", "'Event_Language_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Event_Location_hilo", "'Event_Location_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.Event_Zipcode_hilo", "'Event_Zipcode_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventCatalog.Domain.EventAudience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Event_Audience_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Event_AgeGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EventAudiences");
                });

            modelBuilder.Entity("EventCatalog.Domain.EventCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Event_Category_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Event_Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("EventCatalog.Domain.EventFormat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Event_Format_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Event_Format")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EventFormats");
                });

            modelBuilder.Entity("EventCatalog.Domain.EventItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Event_Item_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Event_Address")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Not Provided");

                    b.Property<int>("Event_AudienceId")
                        .HasColumnType("int");

                    b.Property<int>("Event_Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Event_CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Event_Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("Event_End_Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("Event_FormatId")
                        .HasColumnType("int");

                    b.Property<int>("Event_KindId")
                        .HasColumnType("int");

                    b.Property<int>("Event_LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("Event_LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Event_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Event_Online_Link")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Not Provided");

                    b.Property<string>("Event_Pictureurl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Event_Price")
                        .HasColumnType("Decimal");

                    b.Property<DateTime>("Event_Start_Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Event_UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Event_ZipCodeId")
                        .HasColumnType("int");

                    b.Property<int>("Favorite")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Event_AudienceId");

                    b.HasIndex("Event_CategoryId");

                    b.HasIndex("Event_FormatId");

                    b.HasIndex("Event_KindId");

                    b.HasIndex("Event_LanguageId");

                    b.HasIndex("Event_LocationId");

                    b.HasIndex("Event_ZipCodeId");

                    b.ToTable("EventItems");
                });

            modelBuilder.Entity("EventCatalog.Domain.EventKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Event_Kind_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Event_Kind")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EventKinds");
                });

            modelBuilder.Entity("EventCatalog.Domain.EventLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Event_Language_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Event_Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EventLanguages");
                });

            modelBuilder.Entity("EventCatalog.Domain.EventLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Event_Location_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Event_Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EventLocations");
                });

            modelBuilder.Entity("EventCatalog.Domain.EventZipCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "Event_Zipcode_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Event_Zipcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EventZipcodes");
                });

            modelBuilder.Entity("EventCatalog.Domain.EventItem", b =>
                {
                    b.HasOne("EventCatalog.Domain.EventAudience", "Event_Audience")
                        .WithMany()
                        .HasForeignKey("Event_AudienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalog.Domain.EventCategory", "Event_Category")
                        .WithMany()
                        .HasForeignKey("Event_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalog.Domain.EventFormat", "Event_Format")
                        .WithMany()
                        .HasForeignKey("Event_FormatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalog.Domain.EventKind", "Event_Kind")
                        .WithMany()
                        .HasForeignKey("Event_KindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalog.Domain.EventLanguage", "Event_Language")
                        .WithMany()
                        .HasForeignKey("Event_LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalog.Domain.EventLocation", "Event_Location")
                        .WithMany()
                        .HasForeignKey("Event_LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventCatalog.Domain.EventZipCode", "Event_ZipCode")
                        .WithMany()
                        .HasForeignKey("Event_ZipCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

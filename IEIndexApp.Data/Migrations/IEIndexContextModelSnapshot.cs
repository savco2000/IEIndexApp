using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IEIndexApp.Data.Contexts;
using IEIndexApp.Domain;

namespace IEIndexApp.Data.Migrations
{
    [DbContext(typeof(IEIndexContext))]
    partial class IEIndexContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IEIndexApp.Domain.DomainModels.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hyperlink")
                        .HasMaxLength(200);

                    b.Property<bool>("IsSupplement");

                    b.Property<int>("Issue");

                    b.Property<int>("Page");

                    b.Property<int>("PublicationYear");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("IEIndexApp.Domain.DomainModels.ArticleAuthor", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("AuthorId");

                    b.HasKey("ArticleId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("lnkArticleAuthors");
                });

            modelBuilder.Entity("IEIndexApp.Domain.DomainModels.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Suffix");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("IEIndexApp.Domain.DomainModels.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("IEIndexApp.Domain.DomainModels.SubjectArticle", b =>
                {
                    b.Property<int>("SubjectId");

                    b.Property<int>("ArticleId");

                    b.HasKey("SubjectId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("lnkSubjectArticles");
                });

            modelBuilder.Entity("IEIndexApp.Domain.DomainModels.ArticleAuthor", b =>
                {
                    b.HasOne("IEIndexApp.Domain.DomainModels.Article", "Article")
                        .WithMany("ArticleAuthors")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IEIndexApp.Domain.DomainModels.Author", "Author")
                        .WithMany("ArticleAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IEIndexApp.Domain.DomainModels.SubjectArticle", b =>
                {
                    b.HasOne("IEIndexApp.Domain.DomainModels.Article", "Article")
                        .WithMany("SubjectArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IEIndexApp.Domain.DomainModels.Subject", "Subject")
                        .WithMany("SubjectArticles")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

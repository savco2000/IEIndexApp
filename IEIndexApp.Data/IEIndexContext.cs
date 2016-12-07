using IEIndexApp.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace IEIndexApp.Data.Contexts
{
    public class IEIndexContext : DbContext
    {
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        public IEIndexContext(DbContextOptions options) : base(options)
        {
            
        }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            //Article
            modelBuilder.Entity<Article>().ToTable("Articles");
            modelBuilder.Entity<Article>().HasKey(x => x.Id);
            modelBuilder.Entity<Article>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Article>().Property(x => x.Title).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Article>().Property(x => x.Page).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.Issue).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.PublicationYear).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.IsSupplement).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.Hyperlink).HasMaxLength(200);

            //ArticleAuthors
            modelBuilder.Entity<ArticleAuthor>().ToTable("lnkArticleAuthors");
            modelBuilder.Entity<ArticleAuthor>().HasKey(x => new { x.ArticleId, x.AuthorId });

            //Authors
            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Author>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Author>().Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Author>().Property(x => x.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Author>().HasMany(x => x.ArticleAuthors);

            //SubjectArticles
            modelBuilder.Entity<SubjectArticle>().ToTable("lnkSubjectArticles");
            modelBuilder.Entity<SubjectArticle>().HasKey(x => new { x.SubjectId, x.ArticleId });

            //Subjects
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Subject>().HasKey(x => x.Id);
            modelBuilder.Entity<Subject>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Subject>().Property(x => x.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Subject>().HasMany(x => x.SubjectArticles);
        }
    }
}

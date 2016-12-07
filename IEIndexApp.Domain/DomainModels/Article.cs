using System.Collections.Generic;

namespace IEIndexApp.Domain.DomainModels
{
    public sealed class Article : Entity
    {
        public string Title { get; set; }
        public int Page { get; set; }
        public Issues Issue { get; set; }
        public PublicationYears PublicationYear { get; set; }
        public bool IsSupplement { get; set; }
        public string Hyperlink { get; set; }
        public ICollection<ArticleAuthor> ArticleAuthors { get; set; }
        public ICollection<SubjectArticle> SubjectArticles { get; set; }

        public Article()
        {
            ArticleAuthors = new HashSet<ArticleAuthor>();
            SubjectArticles = new HashSet<SubjectArticle>();
        }
    }
}

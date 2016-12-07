namespace IEIndexApp.Domain.DomainModels
{
    public class ArticleAuthor
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}

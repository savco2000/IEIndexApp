using System.Collections.Generic;

namespace IEIndexApp.Domain.DomainModels
{
    public class Subject : Entity
    {
        public string Name { get; set; }
        public ICollection<SubjectArticle> SubjectArticles { get; set; }

        public Subject()
        {
            SubjectArticles = new HashSet<SubjectArticle>();
        }
    }
}

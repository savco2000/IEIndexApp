using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEIndexApp.Domain.DomainModels
{
    public class SubjectArticle
    {
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }

    }
}

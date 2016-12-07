using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEIndexApp.Domain.DomainModels
{
    public sealed class Author : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Suffixes Suffix { get; set; }
        public string FullName => Suffix == Suffixes.Invalid ? $"{FirstName} {LastName}" : $"{FirstName} {LastName}, {Suffix}";
        public ICollection<Article> Articles { get; set; }

        public Author()
        {
            Articles = new HashSet<Article>();
        }
    }
}

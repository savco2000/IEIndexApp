using System.Collections.Generic;

namespace IEIndexApp.Domain.DTOs
{
    public class SubjectDTO
    {
        public string Name { get; set; }
        public IEnumerable<string> Articles { get; set; }

        public SubjectDTO()
        {
            Articles = new List<string>();
        }
    }
}

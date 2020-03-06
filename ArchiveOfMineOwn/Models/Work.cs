using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArchiveOfMineOwn.Models {
    public class Work {

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Summary { get; set; }
        public int WordCount { get; set; }
        public int Hits { get; set; }
        public int Chapters { get; set; }
        public int? TotalChapters { get; set; }
        public int NumComments { get; set; }
        public int NumKudos { get; set; }
        public int NumBookmarks { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }

        [JsonIgnore]
        public virtual Author Author { get; set; }

        public Work() { }

    }
}

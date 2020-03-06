using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiveOfMineOwn.Models {
    public class Author {
        public int Id { get; set; }
        public string Pseud { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public int NumWorks { get; set; }
        public int NumBookmarks { get; set; }
        public int TotalHits { get; set; }
        public int TotalWordCount { get; set; }
        public DateTime Joined { get; set; }

        public Author() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Models
{
    internal class Manga
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public List<Chapter> Chapters { get; set; } 

        public Manga ()
        {
            Chapters = new List<Chapter> ();
        }

        public Manga (string url, string name)
        {
            this.Url = url;
            this.Name = name;
            Chapters = new List<Chapter> ();
        }

        public override string ToString()
        {
            string r = this.Name + '\n';
            foreach(Chapter chapter in Chapters)
            {
                r += "\r- " + chapter;
            }
            return r;
        }

    }
}

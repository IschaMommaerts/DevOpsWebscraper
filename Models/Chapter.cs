using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Models
{
    internal class Chapter
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public List<string> Images { get; set; }

        public Chapter ()
        {

        }

        public Chapter(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

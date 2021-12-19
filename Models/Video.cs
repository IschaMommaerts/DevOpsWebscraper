using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Models
{
    internal class Video : IEquatable<Video>, IComparable<Video>
    {
        public string Keyword { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Uploader { get; set; }
        public int Views { get; set; }

        public Video ()
        {

        }
        public Video(string Keyword, string Url)
        {
            this.Keyword = Keyword;
            this.Url = Url;
        }

        public override string ToString()
        {
            return String.Format("{0} by {1}: {2} views", this.Title, this.Uploader, this.Views);
        }

        public override int GetHashCode()
        {
            return this.Url.GetHashCode();
        }

        public bool Equals(Video other)
        {
            return this.Url == other.Url;
        }

        public int CompareTo(Video other)
        {
            int compare = this.Keyword.CompareTo(other.Keyword);
            if (compare == 0)
            {
                compare = this.Title.CompareTo(other.Title);
            }
            return compare;
        }
    }
}

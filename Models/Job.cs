using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Models
{
    internal class Job : IEquatable<Job>, IComparable<Job>
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }

        public string SearchTerm { get; set; }

        public Job ()
        {

        }

        public Job(string Title, string Company, string Location, string Link, string SearchTerm)
        {
            this.Title = Title;
            this.Company = Company;
            this.Location = Location;
            this.Link = Link;
            this.SearchTerm = SearchTerm;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.Title, this.Company, this.Location, this.Link);
        }

        public override int GetHashCode()
        {
            return this.Link.GetHashCode();
        }
        public bool Equals(Job other)
        {
            return this.Link == other.Link;
        }

        public int CompareTo(Job other)
        {
            int compare = this.SearchTerm.CompareTo(other.SearchTerm);
            if (compare == 0)
            {
                compare = this.Title.CompareTo(other.Title);
            }
            return compare;
        }
    }
}

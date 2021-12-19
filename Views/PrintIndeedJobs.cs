using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.Views
{
    internal class PrintIndeedJobs
    {
        public static void printJobs(IEnumerable<Job> jobs)
        {
            List<string> searchTerms = new List<string>();
            foreach (var job in jobs)
            {
                if (!searchTerms.Contains(job.SearchTerm))
                {
                    Console.WriteLine(job.SearchTerm + " :");
                    searchTerms.Add(job.SearchTerm);
                }
                Console.WriteLine(" - " + job.ToString());
            }
        }
    }
}

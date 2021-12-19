using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.Views
{
    internal class ListIndeedJobs
    {
        public static void Print(IEnumerable<Job> jobs)
        {
            WebscraperPage.Print("Indeed");
            PrintIndeedJobs.printJobs(jobs);
        }
    }
}

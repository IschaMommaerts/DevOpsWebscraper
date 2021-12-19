using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.Views
{
    internal class RemoveJobPage
    {
        public static void Print(IEnumerable<Job> jobs)
        {
            WebscraperPage.Print("Indeed");
            PrintIndeedJobs.printJobs(jobs);
            Console.WriteLine(" ");
            Console.Write("Enter the search term of the videos you want to remove: ");
        }
    }
}

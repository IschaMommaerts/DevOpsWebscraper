using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Views
{
    static class IntroPage
    {
        public static void Print()
        {
            WebscraperPage.Print("");
            Console.WriteLine("Type Y to query Youtube");
            Console.WriteLine("Type I to query Indeed");
            Console.WriteLine("Type O to query Other");
            Console.WriteLine(" ");
            Console.Write("Enter Choice: ");
        }
    }
}

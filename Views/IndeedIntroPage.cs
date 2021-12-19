using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Views
{
    internal class IndeedIntroPage
    {
        public static void Print()
        {
            WebscraperPage.Print("Indeed");
            Console.WriteLine("Type Q to query indeed job listings.");
            Console.WriteLine("Type C to check stored jobs.");
            Console.WriteLine("Type R to remove a stored job.");
            Console.WriteLine(" ");
            Console.Write("Enter Choice: ");
        }

    }
}

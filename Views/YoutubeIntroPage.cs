using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Views
{
    internal class YoutubeIntroPage
    {
        public static void print()
        {
            WebscraperPage.Print("Youtube");
            Console.WriteLine("Type Q to query youtube videos.");
            Console.WriteLine("Type C to check stored youtube videos.");
            Console.WriteLine("Type R to remove a stored youtube video.");
            Console.WriteLine(" ");
            Console.Write("Enter Choice: ");
        }
    }
}

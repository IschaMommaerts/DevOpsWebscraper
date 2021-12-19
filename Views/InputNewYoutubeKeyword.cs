using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Views
{
    internal class InputNewYoutubeKeyword
    {
        public static void print()
        {
            WebscraperPage.Print("Youtube");
            Console.Write("Enter search term: ");
        }
    }
}

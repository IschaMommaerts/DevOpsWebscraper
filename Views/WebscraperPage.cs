using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Views
{
    internal class WebscraperPage
    {
        public static void Print(string subtitle)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Welcome to WebScraper");
            Console.WriteLine(subtitle);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(" ");
        }
    }
}

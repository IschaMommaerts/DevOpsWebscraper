using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Views
{
    internal class InputNewIndeedSearchTerm
    {
        public static void Print()
        {
            WebscraperPage.Print("Indeed");
            Console.Write("Enter search term: ");
        }
    }
}

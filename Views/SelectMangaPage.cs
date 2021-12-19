using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.Views
{
    internal class SelectMangaPage
    {
        public static void Print(IEnumerable<Manga> mangas)
        {
            WebscraperPage.Print("Manga");
            for (int i = 0; i < mangas.Count(); i++)
            {
                Console.WriteLine(String.Format("{0}. {1}", i, mangas.ElementAt(i)));
            }
            Console.Write("Enter the number of the manga you want to select: ");

        }
    }
}

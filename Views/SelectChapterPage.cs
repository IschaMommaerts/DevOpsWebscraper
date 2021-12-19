using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.Views
{
    internal class SelectChapterPage
    {
        public static void Print(Manga manga)
        {
            WebscraperPage.Print("Manga");
            List<Chapter> chapters = manga.Chapters;
            for (int i = 0; i < chapters.Count(); i++)
            {
                Console.WriteLine(String.Format("{0}. {1}", i, chapters.ElementAt(i)));
            }
            Console.Write("Enter the number of the chapter you want to select: ");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.Views
{
    internal class RemoveVideoPage
    {
        public static void Print(IEnumerable<Video> videos)
        {
            WebscraperPage.Print("Youtube");
            PrintYoutubeVideos.printVideos(videos);
            Console.WriteLine(" ");
            Console.Write("Enter the search term of the videos you want to remove");
        }
    }
}

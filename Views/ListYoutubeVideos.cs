using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.Views
{
    internal class ListYoutubeVideos
    {
        public static void Print(IEnumerable<Video> videos)
        {
            WebscraperPage.Print("Youtube");
            PrintYoutubeVideos.printVideos(videos);
        }
    }
}

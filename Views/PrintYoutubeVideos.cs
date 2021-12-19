using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.Views
{
    internal class PrintYoutubeVideos
    {
        public static void printVideos(IEnumerable<Video> videos)
        {
            List<string> keywords = new List<string>();
            foreach (var video in videos)
            {
                if (!keywords.Contains(video.Keyword)) {
                    Console.WriteLine(video.Keyword + " :");
                    keywords.Add(video.Keyword);
                }
                Console.WriteLine(" - " + video.ToString());
            }
        }
    }
}

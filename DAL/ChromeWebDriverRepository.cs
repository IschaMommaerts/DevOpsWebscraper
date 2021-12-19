using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebScraper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebScraper.DAL
{
    internal class ChromeWebDriverRepository 
    {
        IWebDriver _driver;
        ChromeOptions chromeOptions { get; set; }
        String path { get; set; }
        public ChromeWebDriverRepository(string path)
        {
            this.path = path;
            this.chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            this.chromeOptions.AddArgument("--log-level=3");
        }

        public void Start()
        {
            _driver = new ChromeDriver(path, chromeOptions);
        }

        public List<Video> getYoutube(string keyword)
        {
            string url = string.Format("https://www.youtube.com/results?search_query={0}&sp=CAISAhAB", keyword);
            _driver.Navigate().GoToUrl(url);
            var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(1000);
            By elem_video_link = By.CssSelector("ytd-video-renderer.style-scope.ytd-item-section-renderer");
            ReadOnlyCollection<IWebElement> driverVideos = _driver.FindElements(elem_video_link);

            List<Video> videos = new List<Video>();

            for (int i = 0; i < 5; i++)
            {
                IWebElement driverVideo = driverVideos.ElementAt(i);
                //if (driverVideo.FindElements(By.XPath(".//*[@id='metadata-line']/span[2]")).Count() == 0) continue;
                string videoUrl = driverVideo.FindElement(By.XPath(".//a[@id='thumbnail']")).GetAttribute("href");
                Video video = new Video(keyword, videoUrl);
                videos.Add(video);
            }            
            videos = updateYoutube(videos);
            return videos;
        }

        public List<Video> updateYoutube(List<Video> videos)
        {
            foreach (Video video in videos)
            {
                _driver.Navigate().GoToUrl(video.Url);
                var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(10000));
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                Thread.Sleep(2000);

                string videoTitle = _driver.FindElement(By.CssSelector("h1 > yt-formatted-string")).Text;
                string videoUploader = _driver.FindElement(By.CssSelector("ytd-video-secondary-info-renderer yt-formatted-string.ytd-channel-name")).Text;
                string viewCountString = _driver.FindElement(By.CssSelector("span.view-count")).Text.Split(' ')[0];
                int viewCount = 0;
                Int32.TryParse(viewCountString.Replace(".", ""), out viewCount);             

                video.Title = videoTitle;
                video.Uploader = videoUploader;
                video.Views = viewCount;              
            }

            return videos;
        }

        public List<Job> getJobs(string searchTerm)
        {
            int page = 0;
            bool stop = false;
            List<Job> jobs = new List<Job>();
            do
            {
                string url = string.Format("https://be.indeed.com/jobs?q={0}&sort=date&start={1}", searchTerm, page*10);
                _driver.Navigate().GoToUrl(url);
                var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(10000));
                wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
                Thread.Sleep(2000);

                

                By elem_job_link = By.CssSelector("a[class*=' job_']");
                ReadOnlyCollection<IWebElement> driverJobs = _driver.FindElements(elem_job_link);
                if (driverJobs.Count() == 0) stop = true;
                foreach (var driverJob in driverJobs)
                {
                    string temp = driverJob.FindElement(By.CssSelector(".date")).Text;
                    if (driverJob.FindElement(By.CssSelector(".date")).Text == "Posted\r\n3 dagen geleden")
                    {
                        stop = true;
                        break;
                    }
                    string jobTitle = driverJob.FindElement(By.CssSelector("h2 span:not(.label)")).Text;
                    string jobCompany = driverJob.FindElement(By.CssSelector(".companyName")).Text;
                    string jobLocation = driverJob.FindElement(By.CssSelector(".companyLocation")).Text.Split('\r')[0];
                    string jobLink = driverJob.GetAttribute("href");

                    Job job = new Job(jobTitle, jobCompany, jobLocation, jobLink, searchTerm);
                    jobs.Add(job);
                    
                }
                page++;

            } while (!stop);
                                           
            return jobs;

        }

        public List<Manga> getManga(string searchTerm)
        {
            string url = string.Format("https://manganato.com/search/story/{0}", searchTerm);
            _driver.Navigate().GoToUrl(url);
            var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(1000);

            By elem_manga_link = By.CssSelector(".search-story-item");
            ReadOnlyCollection<IWebElement> driverMangas = _driver.FindElements(elem_manga_link);

            List<Manga> mangas = new List<Manga>();
            foreach (var driverManga in driverMangas)
            {
                string mangaUrl = driverManga.FindElement(By.CssSelector(".item-img")).GetAttribute("href");
                string mangaName = driverManga.FindElement(By.CssSelector("h3")).Text;

                Manga manga = new Manga(mangaUrl, mangaName);
                mangas.Add(manga);
            }
            return mangas;
        }

        public List<Chapter> getChapters(Manga manga)
        {
            string url = manga.Url;
            _driver.Navigate().GoToUrl(url);
            var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(10000));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            Thread.Sleep(1000);

            By elem_chapter_link = By.CssSelector("li.a-h");
            ReadOnlyCollection<IWebElement> driverChapters = _driver.FindElements(elem_chapter_link);
            List<Chapter> chapters = new List<Chapter>();
            foreach (var driverChapter in driverChapters)
            {
                string chapterName = driverChapter.FindElement(By.CssSelector(".chapter-name")).Text;
                string chapterUrl = driverChapter.FindElement(By.CssSelector(".chapter-name")).GetAttribute("href");

                Chapter chapter = new Chapter(chapterName, chapterUrl);
                chapters.Add(chapter);
            }
            return chapters;

        }
        public void Quit()
        {
            _driver.Quit();
        }

    }
}

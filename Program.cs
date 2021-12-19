using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.DAL;
using WebScraper.Models;
using WebScraper.Views;

namespace WebScraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            ChromeWebDriverRepository dv = new ChromeWebDriverRepository(path + @"/drivers");
            VideoRepository videoRepository = new VideoRepository();
            JobRepository jobRepository = new JobRepository();
            SortedSet<Video> videos = new SortedSet<Video>(videoRepository.GetVideos());
            SortedSet<Job> jobs = new SortedSet<Job>(jobRepository.GetJobs());

            do
            {
                IntroPage.Print();

                string choice = Console.ReadLine().Substring(0, 1).ToUpper();
                if (choice == "Y")
                {
                    YoutubeIntroPage.print();
                    choice = Console.ReadLine().Substring(0, 1).ToUpper();
                    if (choice == "Q")
                    {
                        dv.Start();
                        InputNewYoutubeKeyword.print();
                        string keyword = Console.ReadLine();                       
                        List<Video> requestedVideos = dv.getYoutube(keyword);
                        dv.Quit();
                        ListYoutubeVideos.Print(requestedVideos);
                        Console.Write("Add to database? (y/n): ");
                        choice = Console.ReadLine().Substring(0, 1).ToUpper();
                        if (choice == "Y")
                        {
                            foreach (Video video in requestedVideos)
                            {
                                videos.Add(video);
                                videoRepository.InsertVideo(video);
                            }
                        }
                    }
                    else if (choice == "C")
                    {
                        ListYoutubeVideos.Print(videos);
                    }
                    else if (choice == "R")
                    {
                        RemoveVideoPage.Print(videos);
                        string keyword = Console.ReadLine();

                        videos.RemoveWhere(v => v.Keyword == keyword);
                        videoRepository.DeleteVideos(keyword);
                    }

                    Console.ReadLine();
                }
                else if (choice == "I")
                {
                    IndeedIntroPage.Print();
                    choice = Console.ReadLine().Substring(0,1).ToUpper();
                    if (choice == "Q")
                    {
                        dv.Start();
                        InputNewIndeedSearchTerm.Print();
                        string searchTerm = Console.ReadLine();
                        List<Job> requestedJobs = dv.getJobs(searchTerm);
                        dv.Quit();
                        Console.Write("Add to database? (y/n): ");
                        choice = Console.ReadLine().Substring(0, 1).ToUpper();
                        if (choice == "Y")
                        {
                            
                            foreach (Job job in requestedJobs)
                            {
                                Console.WriteLine("test");
                                jobs.Add(job);
                                jobRepository.insertJob(job);
                            }
                        }
                    }
                    if (choice == "C")
                    {
                        ListIndeedJobs.Print(jobs);
                    }
                    else if (choice == "R")
                    {
                        RemoveJobPage.Print(jobs);
                        string searchTerm = Console.ReadLine();

                        jobs.RemoveWhere(j => j.SearchTerm == searchTerm);
                        jobRepository.DeleteJobs(searchTerm);

                    }
                    Console.ReadLine();
                    

                }
                else if (choice == "O")
                {
                    dv.Start();
                    MangaIntroPage.Print();
                    string searchTerm = Console.ReadLine();
                    List<Manga> mangas = dv.getManga(searchTerm);
                    SelectMangaPage.Print(mangas);
                    Manga manga = mangas[Int32.Parse(Console.ReadLine())];
                    manga.Chapters = dv.getChapters(manga);
                    SelectChapterPage.Print(manga);
                    Chapter chapter = manga.Chapters[Int32.Parse((Console.ReadLine()))];


                }

            } while (true);
        }
    }
}

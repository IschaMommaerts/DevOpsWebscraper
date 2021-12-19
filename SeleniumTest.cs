using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using WebScraper.DAL;
using WebScraper.Models;

namespace WebScraper
{
    public class Tests
    {
        ChromeWebDriverRepository dv;
        VideoRepository vr;
        JobRepository jr;

        [OneTimeSetUp]
        public void setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            dv = new ChromeWebDriverRepository(path + @"\Drivers");
            vr = new VideoRepository();
            jr = new JobRepository();

        }

        [Test]
        public void testChapterUrlGetterSetter()
        {
            Chapter chapter = new Chapter();
            string testUrl = "https://readmanganato.com/manga-tz953334/chapter-90";
           
            chapter.Url = testUrl;           

            Assert.AreEqual(testUrl, chapter.Url);           
        }

        [Test]
        public void testChapterNameGetterSetter()
        {
            Chapter chapter = new Chapter();
            string testName = "Chapter 90: The Saint's Motive";

            chapter.Name = testName;

            Assert.AreEqual(testName, chapter.Name);
        }

        [Test]
        public void testChapterConstructor()
        {
            string testUrl = "https://readmanganato.com/manga-tz953334/chapter-90";
            string testName = "Chapter 90: The Saint's Motive";

            Chapter chapter = new Chapter(testName, testUrl);

            Assert.IsTrue(testUrl.Equals(chapter.Url) && testName.Equals(chapter.Name));
        }

        [Test]
        public void testMangaUrlGetterSetter()
        {
            Manga manga= new Manga();
            string testUrl = "https://readmanganato.com/manga-tz953334";

            manga.Url = testUrl;

            Assert.AreEqual(testUrl, manga.Url);
        }

        [Test]
        public void testMangaNameGetterSetter()
        {
            Manga manga = new Manga();
            string testName = "Tensei Shitara Slime Datta Ken";

            manga.Name = testName;

            Assert.AreEqual(testName, manga.Name);
        }

        [Test]
        public void testMangaChaptersGetterSetter()
        {
            Manga manga = new Manga();
            List<Chapter> testChapters = new List<Chapter>();
            testChapters.Add(new Chapter("Chapter 90: The Saint's Motive", "https://readmanganato.com/manga-tz953334/chapter-90"));

            manga.Chapters = testChapters;
            Assert.AreEqual(testChapters, manga.Chapters);
        }

        [Test]
        public void testMangaConstructor()
        {
            string testUrl = "https://readmanganato.com/manga-tz953334";
            string testName = "Tensei Shitara Slime Datta Ken";

            Manga manga = new Manga(testUrl, testName);

            Assert.IsTrue(testUrl.Equals(manga.Url) && testName.Equals(manga.Name));
        }

        [Test]
        public void testVideoKeywordGetterSetter()
        {
            string testKeyword = "football";
            
            Video video = new Video();
            video.Keyword = testKeyword;

            Assert.AreEqual(testKeyword, video.Keyword);
        }

        [Test]
        public void testVideoUrlGetterSetter()
        {
            string testUrl = "https://www.youtube.com/watch?v=8uiR4SrDGZk";

            Video video = new Video();
            video.Url = testUrl;

            Assert.AreEqual(testUrl, video.Url);
        }

        [Test]
        public void testVideoTitleGetterSetter()
        {
            string testTitle = "S.E.S. 'Dreams Come True' MV";

            Video video = new Video();
            video.Title = testTitle;

            Assert.AreEqual(testTitle, video.Title);
        }

        [Test]
        public void testVideoUploaderGetterSetter()
        {
            string testUploader = "SMTOWN";

            Video video = new Video();
            video.Uploader = testUploader;

            Assert.AreEqual(testUploader, video.Uploader);
        }

        [Test]
        public void testVideoViewsGetterSetter()
        {
            int testViews = 6314446;

            Video video = new Video();
            video.Views = testViews;

            Assert.AreEqual(testViews, video.Views);
        }



        [Test]
        public void testVideoConstructor()
        {
            string testKeyword = "football";
            string testUrl = "https://www.youtube.com/watch?v=8uiR4SrDGZk";


            Video video = new Video(testKeyword, testUrl);
            Assert.IsTrue(testKeyword.Equals(video.Keyword) && testUrl.Equals(video.Url));
        }


        [Test]
        public void testJobTitleGetterSetter()
        {
            string testTitle = "Tijdelijk dossierbeheerder te Berchem";

            Job job = new Job();   
            job.Title = testTitle;

            Assert.AreEqual(testTitle, job.Title);
        }

        [Test]
        public void testJobCompanyGetterSetter()
        {
            string testCompany = "Unique";

            Job job = new Job();
            job.Company = testCompany;

            Assert.AreEqual(testCompany, job.Company);
        }

        [Test]
        public void testJobLocationGetterSetter()
        {
            string testLocation = "Berchem";

            Job job = new Job();
            job.Location = testLocation;

            Assert.AreEqual(testLocation, job.Location);
        }

        [Test]
        public void testJobLinkGetterSetter()
        {
            string testLink = "https://be.indeed.com/viewjob?jk=6c672575720d6cd1&tk=1fn9kb761tv2c800&from=serp&vjs=3&advn=6179801996916806&adid=311305802&ad=-6NYlbfkN0BvApDd_KPsNAkdcA3KAhvPzYcLUAJwI8yeayYaXu67fq2zsCwejOLje9-trLFrI45Ri3VDvZNin0sHI8peERsMQhmIUKDe0IOYCX10y3wOBZc12Y1TyeQRIofSFs6W8eHJxLXiEfhfKktJk0_oQArlGznINEdmcvaNnRbMDOdBA6Y1I42tLSez0UZnItJnjHc8I936jXexPSNjsqUN38v0k17bptP6JPjofymCyUVbXqAGnUFhAkaYu0pPJonhRsXu_e2F6LsDCSKEceMoKWpaMz2_tZUC8JNtauKtv61Q4hnW1ZNKHrO5_gsFhHri06bmKwzuyusoyy4Ij0XgpGpN4vjVl9tVUT4nOOHq6YYmxzSIVy3AJZ-x&sjdu=F-SCpDOeWcM1clM4e4Qi1qjyeZRaLkTRzFMfDyz9OE6WfqfsFII4PK_v_YAK8QsgOsDZzDXcYst-GckK1VxStsCfj5ldubh3Ej7vHonW0M0IZDV_LQe_qCK4YFNmbfExOk0GZG-DSLrszUxHQHWWKEiFBQzfMcHEnkQbf-npvi4";

            Job job = new Job();
            job.Link = testLink;

            Assert.AreEqual(testLink, job.Link);
        }

        [Test]
        public void testJobSearchTermGetterSetter()
        {
            string testSearchTerm = "IT";

            Job job = new Job();
            job.SearchTerm = testSearchTerm;

            Assert.AreEqual(testSearchTerm, job.SearchTerm);
        }

        [Test]
        public void testJobConstructor()
        {
            string testTitle = "Tijdelijk dossierbeheerder te Berchem";
            string testCompany = "Unique";
            string testLocation = "Berchem";
            string testLink = "https://be.indeed.com/viewjob?jk=6c672575720d6cd1&tk=1fn9kb761tv2c800&from=serp&vjs=3&advn=6179801996916806&adid=311305802&ad=-6NYlbfkN0BvApDd_KPsNAkdcA3KAhvPzYcLUAJwI8yeayYaXu67fq2zsCwejOLje9-trLFrI45Ri3VDvZNin0sHI8peERsMQhmIUKDe0IOYCX10y3wOBZc12Y1TyeQRIofSFs6W8eHJxLXiEfhfKktJk0_oQArlGznINEdmcvaNnRbMDOdBA6Y1I42tLSez0UZnItJnjHc8I936jXexPSNjsqUN38v0k17bptP6JPjofymCyUVbXqAGnUFhAkaYu0pPJonhRsXu_e2F6LsDCSKEceMoKWpaMz2_tZUC8JNtauKtv61Q4hnW1ZNKHrO5_gsFhHri06bmKwzuyusoyy4Ij0XgpGpN4vjVl9tVUT4nOOHq6YYmxzSIVy3AJZ-x&sjdu=F-SCpDOeWcM1clM4e4Qi1qjyeZRaLkTRzFMfDyz9OE6WfqfsFII4PK_v_YAK8QsgOsDZzDXcYst-GckK1VxStsCfj5ldubh3Ej7vHonW0M0IZDV_LQe_qCK4YFNmbfExOk0GZG-DSLrszUxHQHWWKEiFBQzfMcHEnkQbf-npvi4";
            string testSearchTerm = "IT";

            Job job = new Job(testTitle, testCompany, testLocation, testLink, testSearchTerm);

            Assert.IsTrue(testTitle.Equals(job.Title) && testCompany.Equals(job.Company) && testLocation.Equals(job.Location) && testLink.Equals(job.Link) && testSearchTerm.Equals(job.SearchTerm));

        }

        [Test]
        public void testVideoRepository()
        {
            string testKeyword = "football";
            string testUrl = "https://www.youtube.com/watch?v=8uiR4SrDGZk";
            string testTitle = "S.E.S. 'Dreams Come True' MV";
            string testUploader = "SMTOWN";
            int testViews = 6314446;

            Video video = new Video(testKeyword, testUrl);
            video.Title = testTitle;
            video.Uploader = testUploader;
            video.Views = testViews;

            vr.InsertVideo(video);
            List<Video> videos = (List<Video>)vr.GetVideos();
            Assert.IsTrue(videos.Contains(video));

            vr.DeleteVideos(testKeyword);
            videos = (List<Video>)vr.GetVideos();
            Assert.IsFalse(videos.Contains(video));
        }

        [Test]
        public void testJobRepository()
        {
            string testTitle = "Tijdelijk dossierbeheerder te Berchem";
            string testCompany = "Unique";
            string testLocation = "Berchem";
            string testLink = "https://be.indeed.com/viewjob?jk=6c672575720d6cd1&tk=1fn9kb761tv2c800&from=serp&vjs=3&advn=6179801996916806&adid=311305802&ad=-6NYlbfkN0BvApDd_KPsNAkdcA3KAhvPzYcLUAJwI8yeayYaXu67fq2zsCwejOLje9-trLFrI45Ri3VDvZNin0sHI8peERsMQhmIUKDe0IOYCX10y3wOBZc12Y1TyeQRIofSFs6W8eHJxLXiEfhfKktJk0_oQArlGznINEdmcvaNnRbMDOdBA6Y1I42tLSez0UZnItJnjHc8I936jXexPSNjsqUN38v0k17bptP6JPjofymCyUVbXqAGnUFhAkaYu0pPJonhRsXu_e2F6LsDCSKEceMoKWpaMz2_tZUC8JNtauKtv61Q4hnW1ZNKHrO5_gsFhHri06bmKwzuyusoyy4Ij0XgpGpN4vjVl9tVUT4nOOHq6YYmxzSIVy3AJZ-x&sjdu=F-SCpDOeWcM1clM4e4Qi1qjyeZRaLkTRzFMfDyz9OE6WfqfsFII4PK_v_YAK8QsgOsDZzDXcYst-GckK1VxStsCfj5ldubh3Ej7vHonW0M0IZDV_LQe_qCK4YFNmbfExOk0GZG-DSLrszUxHQHWWKEiFBQzfMcHEnkQbf-npvi4";
            string testSearchTerm = "IT";

            Job job = new Job(testTitle, testCompany, testLocation, testLink, testSearchTerm);

            jr.insertJob(job);
            List<Job> jobs = (List<Job>)jr.GetJobs();
            Assert.IsTrue(jobs.Contains(job));

            jr.DeleteJobs(testSearchTerm);
            jobs = (List<Job>)jr.GetJobs();
            Assert.IsFalse(jobs.Contains(job));
        }

        [Test]
        public void testChromeRepositoryGetYoutube()
        {
            dv.Start();
            List<Video> videos = dv.getYoutube("Football");
            Assert.AreEqual(5, videos.Count);
            dv.Quit();
        }

        [Test]
        public void testChromeRepositoryGetJobs()
        {
            dv.Start();
            List<Job> jobs = dv.getJobs("loodgieter");
            Assert.Greater(jobs.Count, 1);
            dv.Quit();
        }

        [Test]
        public void testChromeRepositoryGetManga()
        {
            dv.Start();
            List<Manga> mangas = dv.getManga("action");
            Assert.Greater(mangas.Count, 1);
            dv.Quit();
        }

        [Test]
        public void testCHromeRepositoryGetChapters()
        {
            dv.Start();
            List<Manga> mangas = dv.getManga("Action");
            List<Chapter> chapters = dv.getChapters(mangas[0]);

            Assert.Greater(chapters.Count, 0);
            dv.Quit();
        }   

        [OneTimeTearDown]   
        public void TearDown()
        {
            
        }
    }
}
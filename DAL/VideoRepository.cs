using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.DAL
{
    internal class VideoRepository : SqlLiteBaseRepository
    {
        public VideoRepository()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }

        public int InsertVideo(Video video)
        {
            string sql = "INSERT INTO Video (Keyword, Url, Title, Uploader, Views) Values (@Keyword, @Url, @Title, @Uploader, @Views);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, video);
            }
        }
        
        public int DeleteVideos(string keyword)
        {
            string sql = "DELETE FROM Video WHERE Keyword = @Keyword;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, new { Keyword = keyword });
            }
        }

        public IEnumerable<Video> GetVideos()
        {
            string sql = "SELECT * FROM Video;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<Video>(sql);
            }
        }
    }
}

using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.Models;

namespace WebScraper.DAL
{
    internal class JobRepository : SqlLiteBaseRepository
    {
        public JobRepository()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }

        public int insertJob(Job job)
        {
            string sql = "INSERT INTO Job (Title, Company, Location, Link, SearchTerm) Values (@Title, @Company, @Location, @Link, @SearchTerm);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, job);
            }
        }

        public int DeleteJobs(string searchTerm)
        {
            string sql = "DELETE FROM Job WHERE SearchTerm = @SearchTerm;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, new { SearchTerm = searchTerm });
            }
        }

        public IEnumerable<Job> GetJobs()
        {
            string sql = "SELECT * FROM Job;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<Job>(sql);
            }
        }
    }
}

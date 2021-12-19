using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.DAL
{
    class SqlLiteBaseRepository
    {
        public SqlLiteBaseRepository()
        {

        }

        public static SqliteConnection DbConnectionFactory()
        {
            return new SqliteConnection(@"DataSource=WebscraperDB.sqlite");
        }

        protected static bool DatabaseExists()
        {
            return File.Exists(@"WebscraperDB.sqlite");
        }

        protected static void CreateDatabase()
        {
            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                connection.Execute(
                    @"CREATE TABLE Video
                    (
                    Id      INTEGER PRIMARY KEY AUTOINCREMENT,
                    Keyword VARCHAR(30),
                    Url     VARCHAR(43) UNIQUE,
                    Title    VARCHAR(100),
                    Uploader VARCHAR(30),
                    Views INTEGER
                    );
                    CREATE TABLE Job
                    (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title VARCHAR(100),
                    Company VARCHAR(30),
                    Location VARCHAR(30),
                    Link VARCHAR(100),
                    SearchTerm VARCHAR(30)
                    );");
            }
        }
    }
}

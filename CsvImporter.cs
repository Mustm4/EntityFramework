using CsvHelper;
using CsvHelper.Configuration;
using EntityFrameworkUppgift.Models;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EntityFrameworkUppgift
{
    public class CsvImporter
    {
        public static List<User> ImportUsers(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<UserMap>();
            var records = csv.GetRecords<User>().ToList();
            return records;
        }

        public static List<Post> ImportPosts(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<PostMap>();
            var records = csv.GetRecords<Post>().ToList();
            return records;
        }

        public static List<Blog> ImportBlogs(string filePath)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<BlogMap>();
            var records = csv.GetRecords<Blog>().ToList();
            return records;
        }

        private sealed class UserMap : ClassMap<User>
        {
            public UserMap()
            {
                Map(m => m.Id).Name("Id");
                Map(m => m.Username).Name("Username");
                Map(m => m.Password).Name("Password");
                Map(m => m.PostId).Name("PostId");
            }
        }

        private sealed class PostMap : ClassMap<Post>
        {
            public PostMap()
            {
                Map(m => m.Id).Name("Id");
                Map(m => m.Title).Name("Title");
                Map(m => m.Content).Name("Content");
                Map(m => m.PublishedOn).Name("PublishedOn");
                Map(m => m.BlogId).Name("BlogId");
                Map(m => m.UserId).Name("UserId");
            }
        }

        private sealed class BlogMap : ClassMap<Blog>
        {
            public BlogMap()
            {
                Map(m => m.Id).Name("Id");
                Map(m => m.Url).Name("Url");
                Map(m => m.Name).Name("Name");
                Map(m => m.PostId).Name("PostId");
            }
        }
    }
}

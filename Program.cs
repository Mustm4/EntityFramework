using EntityFrameworkUppgift;
using EntityFrameworkUppgift.Models;
using EntityFrameworkUppgift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using var dbContext = new AppDbContext();

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        var users = CsvImporter.ImportUsers("user.csv");
        var posts = CsvImporter.ImportPosts("post.csv");
        var blogs = CsvImporter.ImportBlogs("blog.csv");

        AddEntities(dbContext.Users, users);
        AddEntities(dbContext.Posts, posts);
        AddEntities(dbContext.Blogs, blogs);

        dbContext.SaveChanges();

        DisplayDatabaseContent(dbContext);
    }

    static void AddEntities<TEntity>(DbSet<TEntity> dbSet, List<TEntity> entities) where TEntity : class
    {
        dbSet.RemoveRange(dbSet);

        dbSet.AddRange(entities);
    }

    static void DisplayDatabaseContent(AppDbContext dbContext)
    {
        var users = dbContext.Users.ToList();
        foreach (var user in users)
        {
            Console.WriteLine($"User: {user.Username}");
            var userPosts = dbContext.Posts.Where(p => p.UserId == user.Id).ToList();
            foreach (var post in userPosts)
            {
                Console.WriteLine($"\tPost: {post.Title}");
                var blog = dbContext.Blogs.FirstOrDefault(b => b.Id == post.BlogId);
                if (blog != null)
                {
                    Console.WriteLine($"\t\tBlog: {blog.Name}");
                }
            }
        }
    }
}

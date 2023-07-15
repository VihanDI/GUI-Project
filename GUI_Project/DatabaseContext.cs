using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_Project.Models;
using System.IO;
using Microsoft.Data.Sqlite;
using System.Windows;

namespace GUI_Project
{
    public class DatabaseContext : DbContext
    {
        //default constructor
        public DatabaseContext()
        {

        }

        //overloaded constructor created for testing
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        
        DatabaseContext context = null;

        public DatabaseContext CreateContextForSQlite()
        {
            const string connectionString = "Data Source=test.sqlite; Mode=Memory; Cache=Shared";
            var connection = new SqliteConnection(connectionString);
            connection.Open();

            var option = new DbContextOptionsBuilder<DatabaseContext>().UseSqlite(connection).Options;

            context = new DatabaseContext(option);

            if(context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        //private readonly string path = @"D:\Data\Documents\Academics\My Works\GitHub Projects\GUI-Project\GUI_Project\product.db";
        public readonly string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "product.db");

        //public string fullPath = Path.GetFullPath(".");
        //public readonly string path = Path.Combine(Path.GetFullPath("."), "product.db");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");

        public DbSet<Product> ListofProducts { get; set; }
        public DbSet<Transaction> ListofTransactions { get; set; }
        public DbSet<User> ListofUsers { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_Project.Models;

namespace GUI_Project
{
    public class DatabaseContext : DbContext
    {
        private readonly string path = @"D:\Data\Documents\Academics\My Works\GitHub Projects\GUI-Project\GUI_Project\product.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");

        public DbSet<Product> ListofProducts { get; set; }
        public DbSet<Transaction> ListofTransactions { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MovieTheaterAPI.Entity;
using System.Runtime.CompilerServices;

namespace MovieTheaterAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Movies> MovieList { get; set; }
    }
}

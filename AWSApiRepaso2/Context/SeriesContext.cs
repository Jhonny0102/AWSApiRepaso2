using AWSApiRepaso2.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSApiRepaso2.Context
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options)
        {
        }
        public DbSet<Serie> Series { get; set; }
    }
}

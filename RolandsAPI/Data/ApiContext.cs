using Microsoft.EntityFrameworkCore;
using RolandsAPI.Models;

namespace RolandsAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Maja> Majas { get; set; }
        public DbSet<Dzivoklis> Dzivokli { get; set; }
        public DbSet<Iedzivotajs> Iedzivotaji { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using SurveySystem.Models;

namespace SurveySystem.Data
{
    public class KPI_DbContext : DbContext
    {
        public KPI_DbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TblKPI> TblKPI { get; set; }
    }
}

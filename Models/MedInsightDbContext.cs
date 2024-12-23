using Microsoft.EntityFrameworkCore;

namespace MedInsight.Models
{
    public class MedInsightDbContext : DbContext
    {
        public MedInsightDbContext(DbContextOptions<MedInsightDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
}

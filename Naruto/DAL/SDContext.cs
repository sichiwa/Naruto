using System.Data.Entity;
using Naruto.Models;

namespace Naruto.DAL
{
    public class SDContext:DbContext
    {
        public SDContext()
            : base("name=SDContext")
        {
        }
        public DbSet<CheckReportSummaries> CheckReportSummaries { get; set; }
        public DbSet<CheckServers> CheckServers { get; set; }
        public DbSet<CheckReportItems> CheckReportItems { get; set; }
        public DbSet<CheckedDataFiles> CheckedDataFiles { get; set; }
        public DbSet<CheckedDirs> CheckedDirs { get; set; }
        public DbSet<CheckedMainLogs> CheckedMainLogs { get; set; }
    }
}

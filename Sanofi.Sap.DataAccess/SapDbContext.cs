using System.Data.Entity;
using Sanofi.Sap.DataAccess.Requests;
using Sanofi.Sap.Requests;

namespace Sanofi.Sap.DataAccess
{
    public class SapDbContext : DbContext, IDomainContext
    {
        public SapDbContext() : base("POC")
        {
            Database.SetInitializer<SapDbContext>(new CreateDatabaseIfNotExists<SapDbContext>());
        }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RequestConfiguration());
        }
    }
}

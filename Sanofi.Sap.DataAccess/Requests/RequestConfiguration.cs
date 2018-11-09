using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Sanofi.Sap.Requests;

namespace Sanofi.Sap.DataAccess.Requests
{
    public class RequestConfiguration : EntityTypeConfiguration<Request>
    {
        public RequestConfiguration()
        {
            HasKey(r => r.Id);

            Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.Status).HasColumnType("int").IsRequired();
            Property(r => r.Requester).IsRequired().HasMaxLength(200);
            Property(r => r.Message).IsRequired().HasMaxLength(1000);
            Property(r => r.CreatedOn).IsRequired();
            Property(r => r.UpdatedOn).IsOptional();
        }
    }
}

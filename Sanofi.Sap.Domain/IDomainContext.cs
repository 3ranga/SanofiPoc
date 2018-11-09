using System;

namespace Sanofi.Sap
{
    public interface IDomainContext : IDisposable
    {
        int SaveChanges();
    }
}

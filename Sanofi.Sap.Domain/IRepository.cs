namespace Sanofi.Sap
{
    public interface IRepository<TEntiry> where TEntiry : class
    {
        void Save(TEntiry entity);
    }
}
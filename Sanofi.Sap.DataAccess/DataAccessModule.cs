using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Sanofi.Sap.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterType<SapDbContext>()
                .AsSelf()
                .As<IDomainContext>()
                .InstancePerLifetimeScope();
        }
    }
}

using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Sanofi.Sap
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(dataAccess)
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}

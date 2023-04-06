using System.Reflection;
using Autofac;
using ExampleCompanyApp.Caching;
using ExampleCompanyApp.Core.Repositories;
using ExampleCompanyApp.Core.Services;
using ExampleCompanyApp.Core.UnitOfWorks;
using ExampleCompanyApp.Repository;
using ExampleCompanyApp.Repository.Repositories;
using ExampleCompanyApp.Repository.UnitOfWorks;
using ExampleCompanyApp.Service.Mapping;
using Module = Autofac.Module;
using ExampleCompanyApp.Service.Services;

namespace ExampleCompanyApp.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly=Assembly.GetExecutingAssembly();
            var repoAssembly=Assembly.GetAssembly(typeof(ExampleCompanyDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();

            //InstancePerLifetimeScope =>Scope
            //InstancePerDependency =>Transient
            //SingleInstance =>Singleton
        }
    }
}

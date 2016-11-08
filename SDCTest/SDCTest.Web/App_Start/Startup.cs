using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using SDCTest.Data;
using SDCTest.Data.Infrastructure;
using SDCTest.Data.Repositories;
using SDCTest.Web;
using SDCTest.Web.Controllers;

[assembly: OwinStartup(typeof(Startup))]

namespace SDCTest.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            configAutofac();
        }

        private void configAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<NhanVienController>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<SDCTestDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(NhanVienRepository).Assembly)
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces().AsSelf().InstancePerRequest();
        
            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}

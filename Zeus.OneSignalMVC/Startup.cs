using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Web;
using System.Web.Mvc;
using Zeus.OneSignalMVC.Data;
using Zeus.OneSignalMVC.Data.CoreModels;
using Zeus.OneSignalMVC.Mappers;
using Zeus.OneSignalMVC.Models;
using Zeus.OneSignalMVC.Services;

[assembly: OwinStartupAttribute(typeof(Zeus.OneSignalMVC.Startup))]
namespace Zeus.OneSignalMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // REGISTER DEPENDENCIES
            builder.RegisterType<OneSignalDBContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationUser>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<AppService>().As<IAppService>().InstancePerRequest();
            //builder.RegisterAssemblyTypes().Where(t => t.Name.EndsWith("Repository"))
            //   .AsImplementedInterfaces().InstancePerRequest();
            //builder.RegisterAssemblyTypes().Where(t => t.Name.EndsWith("Service"))
            //       .AsImplementedInterfaces().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule<AutoMapperModule>();

            // BUILD THE CONTAINER
            var container = builder.Build();

            // REPLACE THE MVC DEPENDENCY RESOLVER WITH AUTOFAC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // REGISTER WITH OWIN
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            ConfigureAuth(app);
        }
    }
}

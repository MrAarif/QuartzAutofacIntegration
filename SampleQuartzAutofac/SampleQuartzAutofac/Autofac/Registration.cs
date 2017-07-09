using Autofac;
using SamplwQuartzAutofac.Data;

namespace SamplwQuartzAutofac.Autofac
{
    internal class Registration:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppContext>()
                .AsSelf().InstancePerLifetimeScope()
                .WithParameter("nameOrConnectionString", "name=DefaultConnection")
                .AsImplementedInterfaces();
        }
    }
}

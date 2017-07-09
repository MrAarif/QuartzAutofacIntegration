using System.Collections.Specialized;
using Autofac;
using Autofac.Extras.Quartz;
using SamplwQuartzAutofac.Jobs;

namespace SamplwQuartzAutofac.Container
{
    internal static class AutofacContainer
    {
        internal static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(AutofacContainer).Assembly);

            var schedulerConfig = new NameValueCollection {
                {"quartz.threadPool.threadCount", "10"}
            };

            builder.RegisterModule(new QuartzAutofacFactoryModule { ConfigurationProvider = c => schedulerConfig });
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(CreateProductJob).Assembly));
            builder.RegisterType<ServiceCore.ServiceCore>().AsSelf();

            return builder.Build();
        }
    }
}

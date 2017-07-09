using System.Collections.Generic;
using Autofac;
using Quartz;
using SamplwQuartzAutofac.Container;
using SamplwQuartzAutofac.Jobs;
using Topshelf;
using Topshelf.Autofac;
using Topshelf.Quartz;
using Topshelf.ServiceConfigurators;

namespace SamplwQuartzAutofac.AutofacHost
{
    internal static class AutofacQuartzConfig
    {
        internal static void ConfigureAutofac(List<JobConfiguration> jobs)
        {
            var container = AutofacContainer.GetContainer();

            ScheduleJobServiceConfiguratorExtensions.SchedulerFactory = () => container.Resolve<IScheduler>();

            HostFactory.Run(conf =>
            {
                conf.UseAutofacContainer(container);

                conf.Service<ServiceCore.ServiceCore>(svc =>
                {
                    svc.ConstructUsingAutofacContainer();
                    svc.WhenStarted(o => o.Start());
                    svc.WhenStopped(o =>
                    {
                        o.Stop();
                        container.Dispose();
                    });
                    ConfigureScheduler(svc, jobs);
                });
            });
        }

        static void ConfigureScheduler(ServiceConfigurator<ServiceCore.ServiceCore> svc,List<JobConfiguration> jobsConfiguration)
        {
            jobsConfiguration.ForEach(x => ConfigureJob(svc, x));
        }

        private static void ConfigureJob(ServiceConfigurator<ServiceCore.ServiceCore> svc,JobConfiguration job)
        {
            svc.ScheduleQuartzJob(q =>
            {
                q.WithJob(JobBuilder.Create(job.JobType)
                    .WithDescription(job.JobDescription)
                    .Build);
                q.AddTrigger(() => TriggerBuilder.Create()
                    .WithSchedule(SimpleScheduleBuilder.RepeatMinutelyForever(job.JobTriggerInMinutes)).Build());
            });

        }
    }
}

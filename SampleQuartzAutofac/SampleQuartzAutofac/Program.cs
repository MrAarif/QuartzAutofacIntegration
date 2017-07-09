using System;
using System.Collections.Generic;
using SamplwQuartzAutofac.AutofacHost;
using SamplwQuartzAutofac.Jobs;

namespace SamplwQuartzAutofac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var createConfig = new JobConfiguration { JobDescription = "Create", JobTriggerInMinutes = 1, JobType = typeof(CreateProductJob) };
            var updateJob= new JobConfiguration { JobDescription = "Update", JobTriggerInMinutes = 1, JobType = typeof(UpdateProductJob) };
            AutofacQuartzConfig.ConfigureAutofac(new List<JobConfiguration> {createConfig,updateJob});
           

            Console.ReadLine();

        }
    }
}

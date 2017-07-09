using System;
using Quartz;

namespace SamplwQuartzAutofac.Jobs
{
    internal class JobConfiguration
    {
        public Type JobType { get; set; }

        public string JobDescription { get; set; }

        public int JobTriggerInMinutes { get; set; }

        public ITrigger Trigger { get; set; }
    }
}

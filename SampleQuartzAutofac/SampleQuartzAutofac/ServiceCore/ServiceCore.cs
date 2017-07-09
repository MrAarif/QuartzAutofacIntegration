using System;
using Quartz;

namespace SamplwQuartzAutofac.ServiceCore
{
    internal class ServiceCore
    {
        private readonly IScheduler _scheduler;

        public ServiceCore(IScheduler scheduler)
        {
            if (scheduler == null) throw new ArgumentNullException(nameof(scheduler));
            _scheduler = scheduler;
        }

        public bool Start()
        {
            if (!_scheduler.IsStarted)
                _scheduler.Start();     
            return true;
        }

        public bool Stop()
        {
            _scheduler.Shutdown(true);
            return true;
        }
    }
}

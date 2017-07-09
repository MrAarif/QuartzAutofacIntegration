using System;
using Quartz;
using SamplwQuartzAutofac.Data;

namespace SamplwQuartzAutofac.Jobs
{
    internal class CreateProductJob:IJob
    {
        private readonly AppContext _context;

        public CreateProductJob(AppContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public void Execute(IJobExecutionContext context)
        {
            var product = new Product { Name = "prod1", Price = "45$"};
            
            _context.Set<Product>().Add(product);
            _context.SaveChanges();
        }
    }
}

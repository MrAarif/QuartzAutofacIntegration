using System;
using System.Linq;
using Quartz;
using SamplwQuartzAutofac.Data;

namespace SamplwQuartzAutofac.Jobs
{
    internal class UpdateProductJob:IJob
    {
        private readonly AppContext _context;

        public UpdateProductJob(AppContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }

        public void Execute(IJobExecutionContext context)
        {
            var existingProduct = _context.Set<Product>().FirstOrDefault(x => x.Id == "GUID");
            if (existingProduct == null) return;
            
            existingProduct.Name = "prod1Updated";

            _context.Entry(existingProduct).CurrentValues.SetValues(existingProduct);
            _context.SaveChanges();
        }
    }
}

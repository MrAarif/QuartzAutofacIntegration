using System.Data.Entity;

namespace SamplwQuartzAutofac.Data
{
    public class AppContext:DbContext
    {
        public AppContext():base("name=ProductDb")
        {
        }

        public DbSet<Product> Products { get; set; }    
    }
}

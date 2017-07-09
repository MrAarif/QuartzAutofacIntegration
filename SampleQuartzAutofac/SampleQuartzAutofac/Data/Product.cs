using System;

namespace SamplwQuartzAutofac.Data
{
    public class Product
    {
        public Product()
        {
            if (string.IsNullOrEmpty(Id))
                Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

    }
}

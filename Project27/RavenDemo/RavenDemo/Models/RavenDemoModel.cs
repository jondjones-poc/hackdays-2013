using System.Collections.Generic;
using RavenDemo.Classes.ProductFactory;

namespace RavenDemo.Models
{
    public class RavenDemoModel
    {
        public Product UserInformation { get; set; }

        public string ProductName { get; set; }

        public List<Product> Products { get; set; }
    }
}
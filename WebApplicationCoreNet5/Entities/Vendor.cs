using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCoreNet5.Entities
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }

    }
}

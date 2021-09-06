using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCoreNet5.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Отношение one:many
        public int VendorId { get; set; } // Поле не обязательное
        public Vendor Vendor { get; set; }

        public ICollection<Tag> tags { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCoreNet5.Entities
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; } // Поле не обязательное
        public virtual Catalog Parent { get; set; }
    }
}

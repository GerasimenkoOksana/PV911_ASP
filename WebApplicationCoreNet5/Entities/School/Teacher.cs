using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCoreNet5.Entities.School
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Group Group { get; set; }
    }
}

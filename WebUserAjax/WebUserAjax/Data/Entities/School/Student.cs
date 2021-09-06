using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAjax.Data.Entities.School
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GroupId { get; set; }
        // [System.Text.Json.Serialization.JsonIgnore]
        public Group Group { get; set; }
    }
}

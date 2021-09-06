using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


namespace WebUserAjax.Data.Entities.School
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]
        public List<Student> Students { get; set; }

        public int TeacherId { get; set; }

        // [System.Text.Json.Serialization.JsonIgnore]
        public Teacher Teacher { get; set; }

    }
}

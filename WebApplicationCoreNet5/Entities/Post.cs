using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCoreNet5.Entities
{
    public class Post
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }

        // Установка отношений один ко многим
        public Category Category {get; set;} // 1:many

        // Уставновка отношений многие ко многим
        // public ICollection <Tag> tags { get; set; } 


    }
}

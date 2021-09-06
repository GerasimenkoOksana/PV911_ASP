using System.Collections;
using System.Collections.Generic;

namespace WebUserAjax.Data.Entities.Music
{
    public class Label
    {
        public int id { get; set; }

        public string name { get; set; }

        public ICollection<Disc> Discs { get; set; }
    }
}
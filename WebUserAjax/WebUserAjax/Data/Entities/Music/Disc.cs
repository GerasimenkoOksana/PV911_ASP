using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace WebUserAjax.Data.Entities.Music
{
    public class Disc
    {
        public int id { get; set; }

        public string name { get; set; }

        public DateTime dateOfPublish { get; set; }

        public ushort price { get; set; }

       public Band band { get; set;}

       public Label label { get; set; }


    }
}
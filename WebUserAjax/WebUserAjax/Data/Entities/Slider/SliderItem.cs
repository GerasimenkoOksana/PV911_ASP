using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserAjax.Data.Entities.Slider
{
    public class SliderItem
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public int SliderGorupId { get; set; }
        SliderGroup SliderGroup { get; set; }

    }
}

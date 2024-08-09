using System;
using System.Collections.Generic;

#nullable disable

namespace MaxemusAPI.Models
{
    public partial class AboutUs
    {
        public int AboutUsId { get; set; }
        public string AboutUsContent { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}

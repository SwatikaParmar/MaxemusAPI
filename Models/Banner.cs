using System;
using System.Collections.Generic;

namespace MaxemusAPI.Models
{
    public partial class Banner
    {
        public int BannerId { get; set; }
        public string? Name { get; set; } = null!;
        public string? Image { get; set; }
    }
}

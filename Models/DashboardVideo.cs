using System;
using System.Collections.Generic;

namespace MaxemusAPI.Models
{
    public partial class DashboardVideo
    {
        public int DashboardVideoId { get; set; }
        public string? Url { get; set; }
        public string? Thumbnail { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MaxemusAPI.Models
{
    public partial class DashboardItem
    {
        public int DashboardItemId { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Type { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace MaxemusAPI.Models
{
    public partial class TermsAndConditions
    {
        public int TermsAndConditionsId { get; set; }
        public string TermsAndConditionsContent { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}

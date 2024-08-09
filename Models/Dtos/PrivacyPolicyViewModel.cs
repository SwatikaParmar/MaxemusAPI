using System;
using System.Collections.Generic;

namespace MaxemusAPI.ViewModel
{
    public class PrivacyPolicyViewModel
    {
        public string privacyPolicyContent { get; set; }

    }

    public class UpdatePrivacyPolicyViewModels
    {

        public int privacyPolicyId { get; set; }
        public string privacyPolicyContent { get; set; }

    }

    public class PrivacyPolicyAdminViewModels
    {
        public int privacyPolicyId { get; set; }
        public string privacyPolicyContent { get; set; }

    }
}

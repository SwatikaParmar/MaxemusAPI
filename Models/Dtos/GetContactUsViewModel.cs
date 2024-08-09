using System;
using System.Collections.Generic;

namespace MaxemusAPI.ViewModel
{
    public partial class GetContactUsViewModel
    {
        public int contactId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string Subject { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public string createDate { get; set; }
    }

    public partial class ContactUsViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string Subject { get; set; }
        public string email { get; set; }
        public string description { get; set; }
    }
}

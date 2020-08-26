using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfileViewer.Models
{
    public class UserView
    {
        public long Id { get; set; }
        public string ParimaryEmailAddress { get; set; }
        public string AlternateEmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
    }
}
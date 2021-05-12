using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdtt.Models.Account
{
    public class ChangePasswordModel
    {
        public string newpass1 { set; get; }
        public string newpass2 { set; get; }
        public string oldpass { set; get; }
    }
}
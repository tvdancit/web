using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tdtt.Models.Login
{
    [Serializable]
    public class LoginSession
    {
        public string UserName { get; set; }
        public int Type { get; set; }
    }
}
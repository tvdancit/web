using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tdtt.Models.Account
{
    public class AccountModel
    {
        [Required]
        public string Username { set; get; }

        [Required]
        public string Password { set; get; }

        [Required]
        public int Access { set; get; }

        public int Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace web_project.Models.Topic
{
    public class TopicStModel
    {
        [Column(TypeName = "ntext")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string NameSt { get; set; }

        [StringLength(12)]
        public string IdSV { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string IdTy { get; set; }


        [StringLength(10)]
        public string IdP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateSt { get; set; }

        public int? Times { get; set; }
    }
}
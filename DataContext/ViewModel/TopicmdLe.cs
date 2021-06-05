using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.ViewModel
{
    public class TopicmdLe
    {
        [Column(TypeName = "ntext")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Target { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(12)]
        public string IdLe { get; set; }

        [StringLength(10)]
        public string IdP { get; set; }

        //[Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DateSt { get; set; }

        public int? Times { get; set; }

        public double? Expense { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.ViewModel
{
    public class StatementModel
    {
        public int IdDtST { get; set; }
        [Column(TypeName = "ntext")]
        public string Name { get; set; }

        [StringLength(50)]
        public string NameLe { get; set; }

        [Column(TypeName = "ntext")]
        public string Status { get; set; }
    }
}

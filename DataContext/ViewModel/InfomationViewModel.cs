using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.ViewModel
{
    public class InfomationViewModel
    {
        [StringLength(10)]
        public string IdLe { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [Column(TypeName = "ntext")]
        public string NameD { get; set; }
    }
}

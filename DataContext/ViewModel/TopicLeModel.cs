﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.ViewModel
{
    public class TopicLeModel
    {
        [StringLength(10)]
        public string IdTp { get; set; }

        [Column(TypeName = "ntext")]
        public string Name { get; set; }

        [StringLength(50)]
        public string NameLe { get; set; }

        [Column(TypeName = "ntext")]
        public string NameP { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateSt { get; set; }

        public int Times { get; set; }

        public double? Expense { get; set; }

    }
}

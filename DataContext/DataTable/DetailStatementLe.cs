namespace DataContext.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailStatementLe")]
    public partial class DetailStatementLe
    {
        [Key]
        public int IdDtST { get; set; }

        public int? IdSt { get; set; }

        [StringLength(10)]
        public string IdTp { get; set; }


        [Column(TypeName = "ntext")]
        public string Status { get; set; }

        public virtual TopicOfLecture TopicOfLecture { get; set; }

        public virtual Statement Statement { get; set; }
    }
}

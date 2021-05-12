namespace DataContext.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProgressLe")]
    public partial class ProgressLe
    {
        [Key]
        public int IdPr { get; set; }

        [StringLength(10)]
        public string IdTp { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Column(TypeName = "ntext")]
        public string Status { get; set; }

        public virtual TopicOfLecture TopicOfLecture { get; set; }
    }
}

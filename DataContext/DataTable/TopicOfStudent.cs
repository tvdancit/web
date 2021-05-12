namespace DataContext.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TopicOfStudent")]
    public partial class TopicOfStudent
    {
        [Key]
        [StringLength(10)]
        public string IdTp { get; set; }

        [Column(TypeName = "ntext")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string NameSt { get; set; }

        [StringLength(12)]
        public string IdSV { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(10)]
        public string IdP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateSt { get; set; }

        public int? Times { get; set; }

        public double? Expense { get; set; }

        public int? Status { get; set; }

        public virtual PointTable PointTable { get; set; }
    }
}

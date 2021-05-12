namespace DataContext.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TopicOfLecture")]
    public partial class TopicOfLecture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TopicOfLecture()
        {
            DetailStatementLes = new HashSet<DetailStatementLe>();
            ProgressLes = new HashSet<ProgressLe>();
        }

        [Key]
        [StringLength(10)]
        public string IdTp { get; set; }

        [Column(TypeName = "ntext")]
        public string Name { get; set; }

        [StringLength(10)]
        public string IdLe { get; set; }

        [StringLength(10)]
        public string IdP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateSt { get; set; }

        public int? Times { get; set; }

        public double? Expense { get; set; }

        public int? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailStatementLe> DetailStatementLes { get; set; }

        public virtual Information Information { get; set; }

        public virtual PointTable PointTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProgressLe> ProgressLes { get; set; }
    }
}

namespace DataContext.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Notification()
        {
            DetailNotifis = new HashSet<DetailNotifi>();
        }

        [Key]
        public int IdNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateCreat { get; set; }

        [Column(TypeName = "ntext")]
        public string PersonCreat { get; set; }

        [Column(TypeName = "ntext")]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string MetaTile { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Column(TypeName = "ntext")]
        public string FileName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailNotifi> DetailNotifis { get; set; }
    }
}

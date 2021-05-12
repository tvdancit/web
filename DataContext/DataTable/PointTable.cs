namespace DataContext.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PointTable")]
    public partial class PointTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PointTable()
        {
            TopicOfLectures = new HashSet<TopicOfLecture>();
            TopicOfStudents = new HashSet<TopicOfStudent>();
        }

        [Key]
        [StringLength(10)]
        public string IdP { get; set; }

        [StringLength(10)]
        public string IdTy { get; set; }

        [Column(TypeName = "ntext")]
        public string NameP { get; set; }

        [Column(TypeName = "ntext")]
        public string File { get; set; }

        public virtual Type Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopicOfLecture> TopicOfLectures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopicOfStudent> TopicOfStudents { get; set; }
    }
}

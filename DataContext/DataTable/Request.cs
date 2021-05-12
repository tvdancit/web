namespace DataContext.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        [Key]
        public int IdRq { get; set; }

        [Required]
        [StringLength(10)]
        public string IdTp { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Rquest { get; set; }

        [Column(TypeName = "ntext")]
        public string Status { get; set; }

        public virtual TopicOfLecture TopicOfLecture { get; set; }
    }
}


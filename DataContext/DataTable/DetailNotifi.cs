namespace DataContext.DataTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailNotifi")]
    public partial class DetailNotifi
    {
        public int Id { get; set; }

        public int? IdNo { get; set; }

        [Column(TypeName = "ntext")]
        public string DetalContent { get; set; }

        public virtual Notification Notification { get; set; }
    }
}

namespace EF_FROM_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        public int StudentID { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DoB { get; set; }

        public byte[] Photo { get; set; }

        public decimal Height { get; set; }

        public float Weight { get; set; }

        public int StandardId { get; set; }

        public virtual StandardMaster StandardMaster { get; set; }
    }
}

namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Case
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Case()
        {
            Comments = new HashSet<Comment>();
        }

        public int id { get; set; }

        [Required]
        public string CaseId { get; set; }

        [StringLength(128)]
        public string CaseManager_id { get; set; }

        public int? Student_id { get; set; }

        [StringLength(128)]
        public string TeachingAssistant_id { get; set; }

        public int? Unit_id { get; set; }

        public virtual CaseManager CaseManager { get; set; }

        public virtual Student Student { get; set; }

        public virtual TeachingAssistant TeachingAssistant { get; set; }

        public virtual Unit Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}

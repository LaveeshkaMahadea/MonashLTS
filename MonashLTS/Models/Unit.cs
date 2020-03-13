namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Unit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Unit()
        {
            Cases = new HashSet<Case>();
        }

        public int id { get; set; }

        [Required]
        [Display(Name = "Unit Code")]
        public string UnitCode { get; set; }

        [Display(Name = "Deliverable in Alt Offering")]
        public string Deliverable { get; set; }

        [Display(Name = "Primary Teaching Lead Organisation")]
        public string UnitTeachingLeadPrimary { get; set; }

        [Display(Name = "Primary Owning Lead Organisation")]
        public string UnitOwningOrgPrimary { get; set; }

        [Display(Name = "Unit Level")]
        public int UnitLevel { get; set; }

        [Required]
        [Display(Name = "Unit Location")]
        public string UnitLocation { get; set; }

        [Required]
        [Display(Name = "Unit Mode")]
        public string UnitMode { get; set; }

        [Display(Name = "EFTSL")]
        public float Eftsl { get; set; }

        [Display(Name = "Unit Offering Year")]
        public int UnitOfferingYear { get; set; }

        [Display(Name = "Unit Offering Sem")]
        public string UnitOfferingSem { get; set; }

        public int? Student_id { get; set; }

        [StringLength(128)]
        public string TeachingAssistant_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Cases { get; set; }

        public virtual Student Student { get; set; }

        public virtual TeachingAssistant TeachingAssistant { get; set; }
    }
}

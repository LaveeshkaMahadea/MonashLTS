namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeachingAssistant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeachingAssistant()
        {
            Cases = new HashSet<Case>();
            Units = new HashSet<Unit>();
        }

        public string id { get; set; }

        [Required]
        [Display(Name = "Teaching Assistant First Name")]
        public string FirstNameTA { get; set; }

        [Required]
        [Display(Name = "Teaching Assistant Last Name")]
        public string LastNameTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Cases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unit> Units { get; set; }
    }

    [MetadataType(typeof(TAMetadata))]
    public partial class TeachingAssistant
    {
        [Display(Name = "Teaching Assistant Name")]
        public string FullNameTA
        {
            get
            {
                return (FirstNameTA + " " + LastNameTA).Trim();
            }
        }

        public class TAMetadata
        {
        }
    }
}

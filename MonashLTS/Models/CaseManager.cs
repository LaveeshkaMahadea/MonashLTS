namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaseManager()
        {
            Cases = new HashSet<Case>();
            Comments = new HashSet<Comment>();
        }

        public string id { get; set; }

        [Required]
        [Display(Name = "Case Manager First Name")]
        public string FirstNameCM { get; set; }

        [Required]
        [Display(Name = "Case Manager Last Name")]
        public string LastNameCM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Cases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
    }


    [MetadataType(typeof(CMMetadata))]
    public partial class CaseManager
    {
        [Display(Name = "Case Manager Name")]
        public string FullNameCM
        {
            get
            {
                return (FirstNameCM + " " + LastNameCM).Trim();
            }
        }

        public class CMMetadata
        {
        }
    }
}

namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Cases = new HashSet<Case>();
            Units = new HashSet<Unit>();
        }

        public int id { get; set; }

        [Display(Name = "Alternate Offering")]
        public string AlternateOffering { get; set; }

        [Display(Name = "Alternate Offering Option")]
        public string StudentIndication { get; set; }

        [Required]
        [Display(Name = "Student Alias")]
        public string Alias { get; set; }

        [Display(Name = "Chinese Resident ?")]
        public bool ChineseNatOrRez { get; set; }

        [Required]
        [Display(Name = "Assessment Location")]
        public string AssessedLocation { get; set; }

        [Required]
        [Display(Name = "Onshore/Offshore Assessment Location")]
        public string OnshoreOffshore { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Cases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unit> Units { get; set; }
    }
}

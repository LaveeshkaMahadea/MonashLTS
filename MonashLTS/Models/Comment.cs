namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int id { get; set; }

        [Display(Name ="Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Comment")]
        public string CommentText { get; set; }

        [Required]
        public string Action { get; set; }

        [Display(Name = "Closed Date")]
        public DateTime ClosedDate { get; set; }

        [StringLength(128)]
        [Display(Name = "Assigned Case Manager")]
        public string AssignedCM_id { get; set; }

        [Display(Name = "Case ID")]
        public int? CurrentCase_id { get; set; }

        public virtual CaseManager CaseManager { get; set; }

        public virtual Case Case { get; set; }
    }
}

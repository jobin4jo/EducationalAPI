using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbCourseDetail
    {
        public TbCourseDetail()
        {
            TbCertifications = new HashSet<TbCertification>();
            TbReviews = new HashSet<TbReview>();
        }

        public int CourseId { get; set; }
        public string? Price { get; set; }
        public int? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? CategoryId { get; set; }
        public string CourseDescription { get; set; } = null!;
        public string? CourseName { get; set; }
        public string? CourseImageUrl { get; set; }

        public virtual ICollection<TbCertification> TbCertifications { get; set; }
        public virtual ICollection<TbReview> TbReviews { get; set; }
    }
}

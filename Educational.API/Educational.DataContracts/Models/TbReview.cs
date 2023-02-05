using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbReview
    {
        public int ReviewId { get; set; }
        public int? Status { get; set; }
        public string? ReviewDescription { get; set; }
        public int? ReviewRating { get; set; }
        public int? UserId { get; set; }
        public string? ReviewerName { get; set; }
        public string? ReviewerEmail { get; set; }
        public DateTime? ReviewCreatedOn { get; set; }
        public int? CourseId { get; set; }

        public virtual TbCourseDetail? Course { get; set; }
    }
}

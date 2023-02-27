using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbCertification
    {
        public int CertificateId { get; set; }
        public int? CategoryId { get; set; }
        public int? CourseId { get; set; }
        public int? TutorId { get; set; }
        public int? UserId { get; set; }
        public string? CertificationFilePath { get; set; }
        public DateTime? IssueDate { get; set; }
        public string? CreatedBy { get; set; }
        public int? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public int? UpdatedOn { get; set; }

        public virtual TbCourseDetail? Course { get; set; }
        public virtual TbTutor? Tutor { get; set; }
        public virtual TbUser? User { get; set; }
    }
}

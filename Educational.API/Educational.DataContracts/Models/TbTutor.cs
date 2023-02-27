using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbTutor
    {
        public TbTutor()
        {
            TbCertifications = new HashSet<TbCertification>();
        }

        public int Tutorid { get; set; }
        public string? TutorName { get; set; }
        public string TutorDescription { get; set; } = null!;
        public int? Status { get; set; }
        public string? TutorPhotoPath { get; set; }

        public virtual ICollection<TbCertification> TbCertifications { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbUser
    {
        public TbUser()
        {
            TbCertifications = new HashSet<TbCertification>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<TbCertification> TbCertifications { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbProfile
    {
        public int ProfileId { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? EmailId { get; set; }
        public int? UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbCategory
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}

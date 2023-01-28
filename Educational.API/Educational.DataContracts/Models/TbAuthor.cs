using System;
using System.Collections.Generic;

namespace Educational.DataContracts.Models
{
    public partial class TbAuthor
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}

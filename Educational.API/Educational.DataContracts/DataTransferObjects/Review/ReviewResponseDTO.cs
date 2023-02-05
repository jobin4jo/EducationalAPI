using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects.Review
{
   public class ReviewResponseDTO
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
    }
}

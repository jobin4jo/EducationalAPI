using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects.Course
{
    public  class CourseRequestDTO
    {

        public string? CourseName { get; set; }
        public string? CourseImageUrl { get; set; }
        public string? Price { get; set; }
        public int? CategoryId { get; set; }
        public string CourseDescription { get; set; } = null!;
    }


    public class CourseDefaultRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects.Course
{
    public class CourseResponseDTO
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseImageUrl { get; set; }
        public string? Price { get; set; }
        public int? CategoryId { get; set; }
        public string CourseDescription { get; set; } = null!;
    }

    public class PaginationCourseResponseDTO
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }
        public List<CourseResponseDTO> Items { get; init; }
    }
}

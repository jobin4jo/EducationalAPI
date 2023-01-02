using Educational.DataContracts.DataTransferObjects.Course;
using Educational.DataContracts.IRepositories;
using Educational.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.Repositories
{
    public class CourseDetailRepository : ICourseDetailRepository
    {
        public readonly EducationalContext _context;
        public CourseDetailRepository(EducationalContext context)
        {
            _context = context;
        }

        public async Task<int> AddCourseDetail(CourseRequestDTO categoryRequset)
        {
           TbCourseDetail courseDetail = new TbCourseDetail();
            courseDetail.CourseName=categoryRequset.CourseName;
            courseDetail.CourseDescription=categoryRequset.CourseDescription;
            courseDetail.CourseImageUrl = categoryRequset.CourseImageUrl;
            courseDetail.Price=categoryRequset.Price;
            courseDetail.CategoryId = categoryRequset.CategoryId;
            courseDetail.Status = 1;
            courseDetail.CreatedOn = DateTime.Now;
            _context.TbCourseDetails.Add(courseDetail);
            await _context.SaveChangesAsync();
            return courseDetail.CourseId;

        }
    }
}

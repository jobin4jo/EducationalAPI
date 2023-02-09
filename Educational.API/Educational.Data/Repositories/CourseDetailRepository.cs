using Educational.DataContracts.DataTransferObjects.Course;
using Educational.DataContracts.IRepositories;
using Educational.DataContracts.Models;
using Microsoft.EntityFrameworkCore;
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
            this._context = context;
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
            this._context.TbCourseDetails.Add(courseDetail);
            await this._context.SaveChangesAsync();
            return courseDetail.CourseId;

        }

       

        public async Task<List<CourseResponseDTO>> GetAllCourseList()
        {
            List<CourseResponseDTO> courseResponses = await (from course in _context.TbCourseDetails
                                                             where course.Status == 1
                                                             select (new CourseResponseDTO
                                                             {
                                                                 CourseId=course.CourseId,
                                                                 CourseName=course.CourseName,
                                                                 CourseDescription=course.CourseDescription,
                                                                 CourseImageUrl=course.CourseImageUrl,
                                                                 Price=course.Price,
                                                                 CategoryId=course.CategoryId,
                                                                    

                                                             })).ToListAsync();
            return courseResponses;
                                                            
        }

        public async Task<int> DeleteCourse(int courseId)
        {
            var courseData= await _context.TbCourseDetails.FindAsync(courseId);
            courseData.Status = 0;
            courseData.DeletedOn = DateTime.Now;
            _context.Entry(courseData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return courseData.CourseId;


        }

        public async Task<CourseResponseDTO> GetCourseDetailById(int Id)
        {
            CourseResponseDTO responseDTOData = await (from co in _context.TbCourseDetails
                                                       where  co.Status==1 && co.CourseId==Id
                                                       select (new CourseResponseDTO
                                                       {
                                                           CourseName= co.CourseName,
                                                           CourseId= co.CourseId,
                                                           CourseImageUrl = co.CourseImageUrl,
                                                           CategoryId = co.CategoryId,
                                                           CourseDescription = co.CourseDescription,
                                                           Price= co.Price,
                                                           

                                                       })).FirstAsync();
            return responseDTOData;
        }
    }
}

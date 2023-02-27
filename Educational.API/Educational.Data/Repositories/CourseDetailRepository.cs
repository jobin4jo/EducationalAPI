using AutoMapper;
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
        private readonly IMapper _mapper;
        public CourseDetailRepository(EducationalContext context,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<int> AddCourseDetail(CourseRequestDTO categoryRequset)
        {

            TbCourseDetail courseDetail = new TbCourseDetail();
            courseDetail.CourseName = categoryRequset.CourseName;
            courseDetail.CourseDescription = categoryRequset.CourseDescription;
            courseDetail.CourseImageUrl = categoryRequset.CourseImageUrl;
            courseDetail.Price = categoryRequset.Price;
            courseDetail.CategoryId = categoryRequset.CategoryId;
            courseDetail.Status = 1;
            courseDetail.CreatedOn = DateTime.Now;
            this._context.TbCourseDetails.Add(courseDetail);
            await this._context.SaveChangesAsync();
            return courseDetail.CourseId;

        }



        public async Task<List<CourseResponseDTO>> GetAllCourseList(CourseDefaultRequest defaultRequest)
        {
        


            List<TbCourseDetail> courseDetail = await _context.TbCourseDetails.Where(o=>o.Status==1).ToListAsync();
            if (defaultRequest != null)
            {
                courseDetail = courseDetail.Where(o => o.CreatedOn.Value.Date>=defaultRequest.FromDate.Value.Date && o.CreatedOn.Value.Date<=defaultRequest.ToDate.Value.Date).ToList();
            }
            List<CourseResponseDTO> CourseResponse = _mapper.Map<List<TbCourseDetail>,List<CourseResponseDTO>>(courseDetail);
          
            return CourseResponse;


        }

        public async Task<int> DeleteCourse(int courseId)
        {
            var courseData = await _context.TbCourseDetails.FindAsync(courseId);
            courseData.Status = 0;
            courseData.DeletedOn = DateTime.Now;
            _context.Entry(courseData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return courseData.CourseId;


        }

        public async Task<CourseResponseDTO> GetCourseDetailById(int Id)
        {
            CourseResponseDTO responseDTOData = await (from co in _context.TbCourseDetails
                                                       where co.Status == 1 && co.CourseId == Id
                                                       select (new CourseResponseDTO
                                                       {
                                                           CourseName = co.CourseName,
                                                           CourseId = co.CourseId,
                                                           CourseImageUrl = co.CourseImageUrl,
                                                           CategoryId = co.CategoryId,
                                                           CourseDescription = co.CourseDescription,
                                                           Price = co.Price,


                                                       })).FirstAsync();
            return responseDTOData;
        }

        public async Task<List<CourseResponseDTO>> SearchCourseDetails(string courseName)
        {
            List<CourseResponseDTO> courseResponses = await (from course in _context.TbCourseDetails
                                                             where course.Status == 1 && course.CourseName.Contains(courseName)
                                                             select (new CourseResponseDTO
                                                             {
                                                                 CourseId = course.CourseId,
                                                                 CourseName = course.CourseName,
                                                                 CourseDescription = course.CourseDescription,
                                                                 CourseImageUrl = course.CourseImageUrl,
                                                                 Price = course.Price,
                                                                 CategoryId = course.CategoryId,


                                                             })).ToListAsync();
            return courseResponses;
        }

     
    }
}

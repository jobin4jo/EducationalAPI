using Educational.DataContracts.DataTransferObjects.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
    public  interface ICourseDetailRepository
    {
        Task<int> AddCourseDetail(CourseRequestDTO categoryRequset);
    }
}

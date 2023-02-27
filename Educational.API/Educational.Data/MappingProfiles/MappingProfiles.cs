using AutoMapper;
using Educational.DataContracts.DataTransferObjects.City;
using Educational.DataContracts.DataTransferObjects.Country;
using Educational.DataContracts.DataTransferObjects.Course;
using Educational.DataContracts.DataTransferObjects.Review;
using Educational.DataContracts.DataTransferObjects.State;
using Educational.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.Data.MappingProfiles
{
  public  class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            ReviewMappingProfile();
            CourseMappingProfile();
            CountryMappingProfile();
            StateMappingProfile();
            CityMappingProfile();


        }
        public void ReviewMappingProfile()
        {
            CreateMap<TbReview,ReviewResponseDTO>();
           
        }
        public void CourseMappingProfile()
        {
            CreateMap<TbCourseDetail, CourseResponseDTO>();
        }
        public void CountryMappingProfile()
        {
            CreateMap<TbCountry, CountryResponseDTO>();
            CreateMap<CountryRequestDTO, TbCountry>();
        }
        public void StateMappingProfile()
        {
            CreateMap<TbState, StateResponseDTO>();
        }
        public void CityMappingProfile()
        {
            CreateMap<TbCity, CityResponseDTO>();
        }
    }
}

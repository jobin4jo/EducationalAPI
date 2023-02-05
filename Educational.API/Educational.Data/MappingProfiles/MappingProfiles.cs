using AutoMapper;
using Educational.DataContracts.DataTransferObjects.Review;
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

        }
        public void ReviewMappingProfile()
        {
            CreateMap<TbReview,ReviewResponseDTO>();
        }
    }
}

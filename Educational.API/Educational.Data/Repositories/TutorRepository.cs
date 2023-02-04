using Educational.DataContracts.DataTransferObjects.Tutor;
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
    public class TutorRepository : ITutorRepository
    {
        public readonly EducationalContext _context;
        public TutorRepository(EducationalContext  context)
        {
            this._context = context;
        }
        public async  Task<int> CreateTutor(TutorRequestDTO requestDTO)
        {
          TbTutor tbTutor = new TbTutor();  
            tbTutor.TutorName=requestDTO.TutorName;
            tbTutor.TutorPhotoPath=requestDTO.TutorPhotoPath;
            tbTutor.TutorDescription=requestDTO.TutorDescription;
            tbTutor.Status = 1;
            _context.TbTutors.AddAsync(tbTutor);
            await _context.SaveChangesAsync();
            return tbTutor.Tutorid;
        }

        public async Task<bool> DeleteTutor(int id)
        {
            var tutorData = await _context.TbTutors.FindAsync(id);
            tutorData.Status = 0;
            _context.Entry(tutorData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            if (tutorData.Status !=null)
            {
                return true;
            }
            return true;
        }

       

        public async Task<List<TutorResponseDTO>> GetTutorList()
        {
               List<TutorResponseDTO> tutorResponses = await (from tutor in _context.TbTutors
                                                           where tutor.Status==1
                                                           select (new TutorResponseDTO
                                                           {
                                                               Tutorid= tutor.Tutorid,  
                                                               TutorName=tutor.TutorName,
                                                               TutorDescription=tutor.TutorDescription,
                                                               TutorPhotoPath=tutor.TutorPhotoPath

                                                           })).ToListAsync();
            return tutorResponses;
        }

        public async Task<TutorResponseDTO> TutorGetById(int id)
        {
           TutorResponseDTO tutorResponse = await (from tutor in _context.TbTutors
                                                   where tutor.Status==1 && tutor.Tutorid==id
                                                   select (new TutorResponseDTO
                                                   {
                                                       Tutorid=tutor.Tutorid,
                                                       TutorName=tutor.TutorName,
                                                       TutorDescription=tutor.TutorDescription,
                                                       TutorPhotoPath=tutor.TutorPhotoPath

                                                   })).FirstAsync();
            return tutorResponse;
        }

        public async Task<int> UpdateTutor(TutorRequestDTO requestDTO, int id)
        {
            var tutorData = await _context.TbTutors.FindAsync(id);
            tutorData.Tutorid = id;
            tutorData.TutorName=requestDTO.TutorName;
            tutorData.TutorPhotoPath = requestDTO.TutorPhotoPath;
            tutorData.TutorDescription = requestDTO.TutorDescription;
            tutorData.Status = 1;
            _context.Update(tutorData);
            await _context.SaveChangesAsync();
            return tutorData.Tutorid;

        }
    }
}

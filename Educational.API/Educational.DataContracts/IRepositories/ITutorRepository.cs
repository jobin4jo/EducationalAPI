using Educational.DataContracts.DataTransferObjects.Tutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.IRepositories
{
   public  interface ITutorRepository
    {
        Task<int>CreateTutor(TutorRequestDTO requestDTO);  
        Task<int>UpdateTutor(TutorRequestDTO requestDTO,int id );
        Task<bool >DeleteTutor(int id);
        Task<TutorResponseDTO>TutorGetById(int id);
        Task<List<TutorResponseDTO>> GetTutorList();
    }
}

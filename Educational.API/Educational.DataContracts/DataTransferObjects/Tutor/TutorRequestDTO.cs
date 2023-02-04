using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects.Tutor
{
    public  class TutorRequestDTO
    {
       
        public string? TutorName { get; set; }
        public string TutorDescription { get; set; } = null!;
        public int? Status { get; set; }
        public string? TutorPhotoPath { get; set; }
    }
}

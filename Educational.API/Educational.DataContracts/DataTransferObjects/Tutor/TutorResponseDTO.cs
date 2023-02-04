using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational.DataContracts.DataTransferObjects.Tutor
{
    public class TutorResponseDTO
    {
        public int Tutorid { get; set; }
        public string? TutorName { get; set; }
        public string TutorDescription { get; set; } = null!;
        public int? Status { get; set; }
        public string? TutorPhotoPath { get; set; }
    }
}

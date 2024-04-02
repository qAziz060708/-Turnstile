using TurnstileDataAccess.Models;

namespace TurnstileBusinessLogic.DTO.ResponseDTOs
{
    public class StudentResponseDTO
    {
        public string StudentFullName { get; set; }

        public byte[] ContentOfImage { get; set; }

        public string ContentType { get; set; }

        public string Group { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
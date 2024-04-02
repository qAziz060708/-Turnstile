using TurnstileDataAccess.Models;

namespace TurnstileBusinessLogic.DTO.ResponseDTOs
{
    public class StudentResponseDTO
    {
        public int StudentId { get; set; }

        public string StudentFullName { get; set; }

        public byte[] ContentOfImage { get; set; }

        public string ContentType { get; set; }

        public string Group { get; set; }

        public Gender StudentsGender { get; set; }

        public int Age { get; set; }
    }
}
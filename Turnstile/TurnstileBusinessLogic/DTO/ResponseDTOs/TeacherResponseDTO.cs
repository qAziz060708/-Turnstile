using TurnstileDataAccess.Models;

namespace TurnstileBusinessLogic.DTO.ResponseDTOs
{
    public class TeacherResponseDTO
    {
        public string TeacherFullName { get; set; }

        public byte[] ContentOfImage { get; set; }

        public string ContentType { get; set; }

        public string Group { get; set; }

        public Gender2 TeachersGender { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
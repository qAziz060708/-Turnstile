using TurnstileDataAccess.Models;

namespace TurnstileBusinessLogic.DTO.ResponseDTOs
{
    public class TeacherResponseDTO
    {
        public int TeacherId { get; set; }

        public string TeacherFullName { get; set; }

        public byte[] ContentOfImage { get; set; }

        public string ContentType { get; set; }

        public string Group { get; set; }

        public Gender TeachersGender { get; set; }

        public int Age { get; set; }
    }
}
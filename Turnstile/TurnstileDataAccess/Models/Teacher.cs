namespace TurnstileDataAccess.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; }

        public string Group { get; set; }

        public byte[] ContentOfImage { get; set; }

        public string ContentType { get; set; }

        public Gender2 TeachersGender { get; set; }

        public DateTime BirthDate { get; set; }

        public string CommingTime { get; set; }

        public string LeavingTime { get; set; }


        public List<Student> Students { get; set; }
    }
    public enum Gender2
    {
        Male,
        Famale
    }
}
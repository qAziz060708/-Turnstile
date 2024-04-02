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

        public Gender TeachersGender { get; set; }

        public int Age { get; set; }

        public string CommingTime { get; set; }

        public string LeavingTime { get; set; }


        public List<Student> Students { get; set; }
    }
}
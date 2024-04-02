namespace TurnstileDataAccess.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public string Group { get; set; }

        public byte[] ContentOfImage { get; set; }

        public string ContentType { get; set; }

        public Gender StudentsGender { get; set; }

        public int Age { get; set; }

        public string CommingTime { get; set; }

        public string LeavingTime { get; set; }


        public Teacher Teacher { get; set; }
    }
    public enum Gender
    {
        Male,
        Famale
    }
}
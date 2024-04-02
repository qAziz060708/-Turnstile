using AutoMapper;
using TurnstileBusinessLogic.DTO.RequestDTOs;
using TurnstileBusinessLogic.DTO.ResponseDTOs;
using TurnstileDataAccess.Models;

namespace TurnstileBusinessLogic.DTO.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // StudentAutoMapper
            CreateMap<StudentRequestDTO, Student>();
            CreateMap<Student, StudentResponseDTO>()
                .ForMember(studentResponseDTO => studentResponseDTO.StudentFullName,
                opt => opt.MapFrom(student => $"{student.StudentFirstName} {student.StudentLastName}"));

            // TeacherAutoMapper
            CreateMap<TeacherRequestDTO, Teacher>();
            CreateMap<Teacher, TeacherResponseDTO>()
                .ForMember(teacherResponseDTO => teacherResponseDTO.TeacherFullName,
                opt => opt.MapFrom(teacher => $"{teacher.TeacherFirstName} {teacher.TeacherLastName}"));
        }
    }
}
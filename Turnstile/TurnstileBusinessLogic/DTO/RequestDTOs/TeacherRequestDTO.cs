using FluentValidation;
using Microsoft.AspNetCore.Http;
using TurnstileBusinessLogic.DTO.RequestDTOs;
using TurnstileDataAccess.Models;

namespace TurnstileBusinessLogic.DTO.RequestDTOs
{
    public class TeacherRequestDTO
    {
        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; }

        public string Group { get; set; }

        public IFormFile formFile { get; set; }

        public Gender TeachersGender { get; set; }

        public int Age { get; set; }

        public string CommingTime { get; set; }

        public string LeavingTime { get; set; }
    }
}
public class TeacherRequestDTOValidator : AbstractValidator<TeacherRequestDTO>
{
    public TeacherRequestDTOValidator()
    {
        RuleFor(u => u.TeacherFirstName)
            .NotNull().WithMessage("Teacher First Name must be entered.")
            .NotEmpty().WithMessage("Teacher First Name cannot be empty.");

        RuleFor(u => u.TeacherLastName)
            .NotNull().WithMessage("Teacher Last Name must be entered.")
            .NotEmpty().WithMessage("Teacher Last Name cannot be empty.");

        RuleFor(u => u.Group)
            .NotNull().WithMessage("Group must be entered.")
            .NotEmpty().WithMessage("Group cannot be empty.");

        RuleFor(u => u.TeachersGender)
            .NotNull().WithMessage("Teachers Gender must be entered.")
            .IsInEnum().WithMessage("Teachers Gender Entered incorrectly.");

       // RuleFor(u => u.BirthDate)
           // .NotNull().WithMessage("Birth date must be entered.")
           // .NotEmpty().WithMessage("Birth date cannot be empty.");

        RuleFor(u => u.CommingTime)
            .NotNull().WithMessage("Comming Time must be entered.")
            .NotEmpty().WithMessage("Comming Time cannot be empty.");

        RuleFor(u => u.LeavingTime)
            .NotNull().WithMessage("Leaving Time must be entered.")
            .NotEmpty().WithMessage("Leaving Time cannot be empty.");
    }
}
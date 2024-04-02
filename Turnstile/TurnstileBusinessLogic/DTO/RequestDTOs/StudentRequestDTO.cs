using FluentValidation;
using Microsoft.AspNetCore.Http;
using TurnstileBusinessLogic.DTO.RequestDTOs;
using TurnstileDataAccess.Models;

namespace TurnstileBusinessLogic.DTO.RequestDTOs
{
    public class StudentRequestDTO
    {
        public string StudentFirstName { get; set; }

        public string StudentLastName { get; set; }

        public string Group { get; set; }

        public IFormFile formFile { get; set; }

        public Gender StudentsGender { get; set; }

        public int Age { get; set; }

        public string CommingTime { get; set; }

        public string LeavingTime { get; set; }

        public int TeacherId { get; set; }
    }
}
public class StudentRequestDTOValidator : AbstractValidator<StudentRequestDTO>
{
    public StudentRequestDTOValidator()
    {
        RuleFor(u => u.StudentFirstName)
            .NotNull().WithMessage("Student First Name must be entered.")
            .NotEmpty().WithMessage("Student First Name cannot be empty.");

        RuleFor(u => u.StudentLastName)
            .NotNull().WithMessage("Student Last Name must be entered.")
            .NotEmpty().WithMessage("Student Last Name cannot be empty.");

        RuleFor(u => u.Group)
            .NotNull().WithMessage("Group must be entered.")
            .NotEmpty().WithMessage("Group cannot be empty.");

        RuleFor(u => u.StudentsGender)
            .NotNull().WithMessage("Students Gender must be entered.")
            .IsInEnum().WithMessage("Students Gender Entered incorrectly.");

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
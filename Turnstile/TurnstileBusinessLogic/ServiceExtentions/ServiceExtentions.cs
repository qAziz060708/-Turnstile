using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TurnstileBusinessLogic.DTO.RequestDTOs;
using TurnstileBusinessLogic.Service.IServices;
using TurnstileBusinessLogic.Service.Services;
using TurnstileDataAccess.Repository.IRepositories;
using TurnstileDataAccess.Repository.Repositories;

namespace TurnstileBusinessLogic.ServiceExtentions
{
    public static class ServiceExtentions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Mvc
            services.AddMvc();

            // Validation
            services.AddScoped<IValidator<StudentRequestDTO>, StudentRequestDTOValidator>();
            services.AddScoped<IValidator<TeacherRequestDTO>, TeacherRequestDTOValidator>();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            // Services
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
        }
    }
}
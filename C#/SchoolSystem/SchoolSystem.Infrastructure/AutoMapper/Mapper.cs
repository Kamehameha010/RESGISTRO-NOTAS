using AutoMapper;
using SchoolSystem.Core.DTOs;
using SchoolSystem.Core.Entities;

namespace SchoolSystem.Infrastructure.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Rol, RolDTO>().ReverseMap();
            CreateMap<CourseGradebook, CourseGradebookDTO>().ReverseMap();
        }
    }
}
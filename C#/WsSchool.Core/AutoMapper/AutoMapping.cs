
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WsSchool.Core.Models.DTOs;
using WsSchool.Core.Models.Entities;

namespace WsSchool.Core.AutoMapper
{
     public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //Person Profile
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();

            //Course Profile
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseDTO, Course>();

            //Gradebook Profile
            CreateMap<Gradebook, GradeBookDTO>();
            CreateMap<GradeBookDTO, Gradebook>();

            //Login Profile
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            //Student Profile
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();

            //Teacher Profile
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();

        }
    }
}

namespace SchoolSystem.Core.DTOs
{
    public class UserTeacherDTO
    {
        public UserDTO User { get; set; }
        public TeacherDTO Teacher { get; set; }
        public void Deconstruct(out UserDTO userDTO, out TeacherDTO teacherDTO){
            userDTO =  User;
            teacherDTO = Teacher;
        }
    }
}
namespace SchoolSystem.Core.DTOs
{
    public class UserStudentDTO
    {
        public UserDTO User { get; set; }
        public StudentDTO Student { get; set; }


        public void Deconstruct(out UserDTO userDTO, out StudentDTO studentDTO)
        {
            userDTO = User;
            studentDTO = Student;
        }
    }
}
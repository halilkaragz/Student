using StudentCore.DTOs;

namespace StudentCore.Interfaces;

public interface IStudentService
{   
    Task CreateStudentAsync(StudentDto studentDto);
}
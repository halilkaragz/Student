using StudentCore.DTOs;
using StudentCore.Entities;
using StudentCore.Interfaces;
using StudentDataAccess.Repositories;

namespace StudentBusiness.Services;

public class StudentManager : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    public StudentManager(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task CreateStudentAsync(StudentDto studentDto)
    {
        //DTO'dan Entity'e manuel dönüşüm
        var student = new Student
        {
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            BirthDate = studentDto.BirthDate,
            CreatedDate = DateTime.UtcNow           
        };

        await _studentRepository.AddAsync(student);
    }
}
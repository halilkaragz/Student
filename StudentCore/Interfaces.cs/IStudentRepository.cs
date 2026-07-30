
using StudentCore.Entities;

namespace StudentCore.Interfaces;
public interface IStudentRepository
{
    Task AddAsync(Student student);
}
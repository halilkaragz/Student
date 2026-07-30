using StudentCore.Entities;
using StudentCore.Interfaces;

namespace StudentDataAccess.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;
    public StudentRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }
    
}
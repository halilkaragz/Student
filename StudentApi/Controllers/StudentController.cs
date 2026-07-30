using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentCore.DTOs;
using StudentCore.Interfaces;

namespace StudentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IExternalStudentService _externalStudentService;
    public StudentController(IStudentService studentService, IExternalStudentService externalStudentService)
    {
        _studentService = studentService;  
        _externalStudentService = externalStudentService;      
    }

    [HttpPost]
    public async Task<IActionResult> Create(StudentDto studentDto)
    {
        await _studentService.CreateStudentAsync(studentDto);
        return StatusCode(201); //Başarıyla oluşturuldu (Created)
    }

    [HttpGet("external/{id}")]
    public async Task<IActionResult> GetExternalStudent(int id)
    {
        var student = await _externalStudentService.GetExternalStudentDtoByIdAsync(id);

        if (student == null)
        {
            return NotFound(new {message = "{id} numaralı öğrenci dış kaynaktan öğrenci bulunamadı."});
        }

        return Ok(student);
    }

    [HttpGet("GetAllExternal")]
    public async Task<IActionResult> GetAllExternalStudents()
    {
        var results = await _externalStudentService.GetAllExternalStudentDto();
        if(results == null)
        {
            return BadRequest("Kullanıcılar yüklenemedi");
        }

        return Ok(results);
        
    }

}
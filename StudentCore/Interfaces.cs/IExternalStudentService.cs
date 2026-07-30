public interface IExternalStudentService
{
    Task<ExternalStudentDto?> GetExternalStudentDtoByIdAsync(int id);
    Task<List<ExternalStudentDto>?> GetAllExternalStudentDto();
}
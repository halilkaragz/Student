public interface IExternalStudentService
{
    Task<ExternalStudentDto?> GetExternalStudentDtoByIdAsync(int id);
}
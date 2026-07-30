using System.Net.Http.Json;

namespace StudentBusiness.Services;
public class ExternalStudentManager : IExternalStudentService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ExternalStudentManager(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;        
    }

    public async Task<List<ExternalStudentDto>?> GetAllExternalStudentDto()
    {
        var client = _httpClientFactory.CreateClient();
        var url = $"https://jsonplaceholder.typicode.com/users";
        try
        {
            var userList = await client.GetFromJsonAsync<List<ExternalStudentDto>>(url);
            return userList;            
        }
        catch (System.Exception)
        {      
            // atayı yukarı fırlatıyoruz           
            throw;
        }
    }

    public async Task<ExternalStudentDto?> GetExternalStudentDtoByIdAsync(int id)
    {
        var client =_httpClientFactory.CreateClient();
        //örnek bir dış api adresi
        var url = $"https://jsonplaceholder.typicode.com/users/{id}";
        try
        {
            var rawUser = await client.GetFromJsonAsync<JsonPlaceholderUser>(url);
            if(rawUser != null)
            {
                return new ExternalStudentDto
                {
                    id = rawUser.Id,
                    Name = rawUser.Name,
                    Email = rawUser.Email,
                    Address = rawUser.Address
                };
                
            }
            return null;
        }
        catch(HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
           // 404 Hatası alındığında (id bulunamadığında) null döner
            return null;
        }
        
    }
}
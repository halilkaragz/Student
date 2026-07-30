using System.Net.Http.Json;

namespace StudentBusiness.Services;
public class ExternalStudentManager : IExternalStudentService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ExternalStudentManager(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;        
    }
    public async Task<ExternalStudentDto?> GetExternalStudentDtoByIdAsync(int id)
    {
        var client =_httpClientFactory.CreateClient();
        //örnek bir dış api adresi
        var url = $"https://jsonplaceholder.typicode.com/users{id}";
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
                    City = rawUser.Address.City
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
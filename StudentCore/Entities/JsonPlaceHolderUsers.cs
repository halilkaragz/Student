// JSONPlaceholder /users yapısına birebir uyan geçici iç model
public class JsonPlaceholderUser{
    public int id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public JsonPlaceHolderAddress? Address { get; set; } 
    public JsonPlaceHolderGeo? Geo { get; set; }
    public string? Phone { get; set; }   
    public string? Website { get; set; } 
    public JsonPlaceHolderCompany? Company { get; set; }
}
// JSONPlaceholder /users yapısına birebir uyan geçici iç model
public class JsonPlaceholderUser
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public JsonPlaceholderAddress Address { get; set; } = new();
}
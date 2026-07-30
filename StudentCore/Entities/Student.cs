namespace StudentCore.Entities;

public class Student
{
    public int Id { get; set; } 
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now; // Kayıt tarihi
}
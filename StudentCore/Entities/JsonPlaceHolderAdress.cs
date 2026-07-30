public class JsonPlaceHolderAddress
{
    public string Street { get; set; } = string.Empty;
    public string? Suite { get; set; }
    public string? City { get; set; }
    public string? Zipcode { get; set; }
    public JsonPlaceHolderGeo? Geo { get; set; }
}
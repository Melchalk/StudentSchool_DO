namespace DbModels;

public class DbBook
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Author { get; set; }
    public int Number_pages { get; set; }
    public int Year_publishing { get; set; }
    public string? City_publishing { get; set; }
    public int? Hall_no { get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModels;

public class DbReader
{
    public Guid Id { get; set; }
    public string Fullname {  get; set; }
    public string Telephone {  get; set; }
    public string?  Registration_address { get; set; }
    public int? Age { get; set; }
}
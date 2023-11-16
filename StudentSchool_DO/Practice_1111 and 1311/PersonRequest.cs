using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lesson;

public class PersonRequest
{
public string? Name { get; set; }

public int Age { get; set; }

public Guid OfficeId { get; set; }

public bool HasJob { get; set; }

public string? Company { get; set; }
}

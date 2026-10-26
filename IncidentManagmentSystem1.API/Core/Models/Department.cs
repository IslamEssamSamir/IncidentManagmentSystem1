using System.ComponentModel.DataAnnotations;

namespace IncidentManagmentSystem1.API.Core.Models;

public class Department : BaseModel
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UniterEntity.Model;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }
}

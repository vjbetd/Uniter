using System.ComponentModel.DataAnnotations;

namespace UniterApp.Models;

public record UserModel
{
    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Email { get; set; }
}

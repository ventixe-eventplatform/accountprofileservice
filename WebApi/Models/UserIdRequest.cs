using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class UserIdRequest
{
    [Required]
    public string Id { get; set; } = null!;
}

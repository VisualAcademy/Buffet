using System.ComponentModel.DataAnnotations;

namespace Hawaso.Models.Buffets;

/// <summary>
/// 고명 
/// </summary>
public class Garnish
{
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string? Name { get; set; }

    public int? NoodleId { get; set; }

    public Noodle? Noodle { get; set; }
}

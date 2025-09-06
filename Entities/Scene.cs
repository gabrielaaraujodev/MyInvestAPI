using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyInvest.Entities;

public class Scene
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(20)]
    public string Types { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string Assets { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string Dates { get; set; } = string.Empty;

    // Chave Estrangeira.
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    // Propriedade de navegação.
    public User User { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;

namespace MyInvest.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    // Propriedades de navegação.
    public List<Transaction> Transactions { get; set; } = new();
    public List<Scene> Scenes { get; set; } = new();
}


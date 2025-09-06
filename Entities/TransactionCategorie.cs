using System.ComponentModel.DataAnnotations;

namespace MyInvest.Entities;

public class TransactionCategory
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(30)]
    public string Category { get; set; } = string.Empty;

    // Propriedade de navegação.
    public List<Transaction> Transactions { get; set; } = new ();
}

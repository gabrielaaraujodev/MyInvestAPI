using System.ComponentModel.DataAnnotations;

namespace MyInvest.Entities;

public class TransactionType
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(1)]
    public string Abbreviation { get; set; } = string.Empty;
    [Required]
    [StringLength(1)]
    public string OperationSignal { get; set; } = string.Empty;

    // Propriedade de navegação.
    public List<Transaction> Transactions { get; set; } = new ();
}

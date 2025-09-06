using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyInvest.Entities;

public class Transaction
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; }
    [Required]
    public string Asset { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public int UnitValue { get; set; }

    // Chaves Estrangeiras.
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    [ForeignKey(nameof(TransactionCategory))]
    public int TransactionCategoryId { get; set; }
    [ForeignKey(nameof(TransactionType))]
    public int TransactionTypeId { get; set; }

    // Propriedades de navegação.
    public User User { get; set; } = null!;
    public TransactionCategory TransactionCategory { get; set; } = null!;
    public TransactionType TransactionType { get; set; } = null!;
}

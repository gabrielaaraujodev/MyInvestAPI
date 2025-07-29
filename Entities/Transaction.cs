namespace MyInvest.Entities;

public class Transaction
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Asset { get; set; }
    public decimal Amount { get; set; } 
    public int UnitValue { get; set; }

    // Chaves Estrangeiras.
    public int UserId { get; set; }
    public int TransactionCategoryId { get; set; }
    public int TransactionTypeId { get; set; }

    // Propriedades de navegação.
    public User User { get; set; }
    public TransactionCategory TransactionCategory { get; set; }
    public TransactionType TransactionType { get; set; }
}

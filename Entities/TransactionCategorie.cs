namespace MyInvest.Entities;

public class TransactionCategory
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;

    // Propriedade de navegação.
    public List<Transaction> Transactions { get; set; } = new ();
}

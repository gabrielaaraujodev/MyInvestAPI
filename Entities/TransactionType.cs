namespace MyInvest.Entities;

public class TransactionType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = string.Empty;
    public string OperationSignal { get; set; } = string.Empty;

    // Propriedade de navegação.
    public List<Transaction> Transactions { get; set; } = new ();
}

namespace MyInvest.Entities;

public class TransactionType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string OperationSignal { get; set; }

    // Propriedade de navegação.
    public List<Transaction> Transactions { get; set; }
}

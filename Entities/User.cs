namespace MyInvest.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    // Propriedades de navegação.
    public List<Transaction> Transactions { get; set; } = new();
    public List<Scene> Scenes { get; set; } = new();
}


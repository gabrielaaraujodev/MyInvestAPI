namespace MyInvest.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Propriedades de navegação.
    public List<Transaction> Transactions { get; set; }
    public List<Scene> Scenes { get; set; }
}


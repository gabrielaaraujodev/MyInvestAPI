namespace MyInvest.Entities;

public class Scene
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Types { get; set; }
    public string Assets { get; set; }
    public string Dates { get; set; }

    // Chave Estrangeira.
    public int UserId { get; set; }

    // Propriedade de navegação.
    public User User { get; set; }
}

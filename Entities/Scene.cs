namespace MyInvest.Entities;

public class Scene
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Types { get; set; } = string.Empty;
    public string Assets { get; set; } = string.Empty;
    public string Dates { get; set; } = string.Empty;

    // Chave Estrangeira.
    public int UserId { get; set; }

    // Propriedade de navegação.
    public User User { get; set; } = null!;
}

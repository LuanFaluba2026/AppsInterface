namespace AppsInterface.Components.Models;
public class User
{
    public Guid Id { get; set;} = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public bool IsAdmin { get; set; } = false;
    public string PasswordHash { get; set; } = string.Empty;
}
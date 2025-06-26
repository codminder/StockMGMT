namespace WebApp.Models;

public class User
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required DateTime Created { get; set; }
    public required DateTime LastLoginDate { get; set; }
    public string? ResetHeshCode { get; set; }
    public required ICollection<Product> Products { get; set; }
}
namespace MoneyZip.Domain;

public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Wallet Wallet { get; set; }

    public string SetPassword(string password)
    {
        Password = password;

        return Password;
    }

   
}
namespace MoneyZip.Domain;

public class Wallet
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public WalletType Type { get; set; }
    public decimal Balance { get; set; }
    
}
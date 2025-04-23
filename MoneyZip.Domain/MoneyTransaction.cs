namespace MoneyZip.Domain;

public class MoneyTransaction
{
    public Guid Id { get; set; }
    public Guid PayerWalletId { get; set; }
    public Guid PayeeWalletId { get; set; }
    public decimal Amount { get; set; }
    public DateTime ProcessedAt { get; set; }
}
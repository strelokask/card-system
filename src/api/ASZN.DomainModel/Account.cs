namespace ASZN.DomainModel
{
    public enum AccountType
    {
        Unknown,
        Deposit,
        Credit,
        Currency
    }
    public class Account : BaseEntity
    {
        public float Balance { get; set; }
        public AccountType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
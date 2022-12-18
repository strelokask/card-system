using System.ComponentModel.DataAnnotations;

namespace ASZN.DomainModel
{
    public enum CardState
    {
        Unknown,
        Active,
        Disabled,
        Expired
    };
    public enum CardType
    {
        Unknown,
        Forint,
        Currency,
        Credit
    };

    public class Card : BaseEntity
    {
        public string CardNumber { get; set; }
        public bool IsValid { get; set; }
        public CardState State { get; set; }
        public CardType Type { get; set; }
    }
}
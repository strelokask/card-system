using System.ComponentModel.DataAnnotations;

namespace ASZN.DomainModel
{
    public enum TranactionType
    {
        Normal,
        Cancelled
    }
    public class Transaction : BaseEntity
    {
        public DateTimeOffset Date { get; set; }
        public float Amount { get; set; }
        public TranactionType Type { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
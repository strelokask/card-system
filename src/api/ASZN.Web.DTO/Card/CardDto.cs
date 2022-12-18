using ASZN.DomainModel;

namespace ASZN.Web.DTO.Card
{
    public class CardDto
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public bool IsValid { get; set; }
        public CardState State { get; set; }
        public CardType Type { get; set; }
    }
}

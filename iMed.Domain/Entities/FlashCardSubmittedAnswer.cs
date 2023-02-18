namespace iMed.Domain.Entities;

public class FlashCardSubmittedAnswer : ApiEntity
{
    public int FlashCardSubmittedAnswerId { get; set; }
    public bool IsTrue { get; set; }
    public int Row { get; set; }
    public double ElapsedTimePerSecond { get; set; }
    public int FlashCardId { get; set; }
    public FlashCard FlashCard { get; set; }
    public int FlashCardAnswerId { get; set; }
    public FlashCardAnswer FlashCardAnswer { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
namespace iMed.Domain.Dtos.SmalDtos;
public class SpecialOfferSDto
{
    public SpecialOfferType SpecialOfferType { get; set; }
    public CourseSDto Course { get; set; }
    public FlashCardCategorySDto FlashCardCategory { get; set; }
}
public enum SpecialOfferType
{
    Course,
    FlashCard
}

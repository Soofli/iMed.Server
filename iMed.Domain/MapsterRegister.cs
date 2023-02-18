namespace iMed.Domain;

public class MapsterRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Course, CourseSDto>()
            .Map(des => des.CourseCategoryName, org => org.CourseCategory != null ? org.CourseCategory.Name : null)
            .Map(des => des.ImageFileName, org => org.Image != null ? org.Image.FileName : null)
            .TwoWays();

        config.NewConfig<Course, CourseLDto>()
            .Map(des => des.CourseCategoryName, org => org.CourseCategory != null ? org.CourseCategory.Name : null)
            .Map(des => des.ImageFileName, org => org.Image != null ? org.Image.FileName : null)
            .TwoWays();

        config.NewConfig<FlashCard, FlashCardSDto>()
            .Map(des => des.FlashCardTagName, org => org.FlashCardTag != null ? org.FlashCardTag.Name : null)
            .Map(des => des.FlashCardCategoryId, org => org.FlashCardTag != null ? org.FlashCardTag.FlashCardCategoryId : 0);

        config.NewConfig<FlashCardCategory, FlashCardCategorySDto>()
            .Map(des => des.ImageFileName, org => org.Image != null ? org.Image.FileName : null)
            .TwoWays();

        config.NewConfig<FlashCardCategory, FlashCardCategoryLDto>()
            .Map(des => des.ImageFileName, org => org.Image != null ? org.Image.FileName : null)
            .TwoWays();

        config.NewConfig<FlashCardCategoryRate, FlashCardCategoryRateSDto>()
            .Map(des => des.FlashCardCategoryName, org => org.FlashCardCategory != null ? org.FlashCardCategory.Name : null)
            .TwoWays();

        config.NewConfig<CourseRate, CourseRateSDto>()
            .Map(des => des.CourseName, org => org.Course != null ? org.Course.Name : null)
            .TwoWays();

        config.NewConfig<User, UserSDto>()
            .Map(des => des.UserIdentityImageFileName, org => org.UserIdentityImage != null ? org.UserIdentityImage.FileName : null)
            .TwoWays();

        config.NewConfig<UserFlashCardStatus, UserFlashCardStatusLDto>()
            .Map(des => des.Question, org => org.FlashCard != null ? org.FlashCard.Question : null)
            .Map(des=>des.FlashCardType,org=>org.FlashCard != null ? org.FlashCard.FlashCardType:FlashCardType.SingleAnswer)
            .Map(des=>des.FlashCardAnswers,org=> org.FlashCard != null ? org.FlashCard.FlashCardAnswers : null)
            .Map(des=>des.LongAnswer,org=>org.FlashCard !=null ? org.FlashCard.LongAnswer : null)
            .Map(des=>des.FlashCardTagName ,org=>org.FlashCard.FlashCardTag !=null ? org.FlashCard.FlashCardTag.Name : null)
            .Map(des=>des.FlashCardCategoryId , org=>org.FlashCard.FlashCardTag.FlashCardCategoryId)
            .Map(des=>des.FlashCardCategoryName ,org=> org.FlashCard.FlashCardTag.FlashCardCategory != null ? org.FlashCard.FlashCardTag.FlashCardCategory.Name : null);


    }
}
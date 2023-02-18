namespace iMed.Domain.Dtos.PageDto;

public class SearchPageDto
{
    public ObservableCollection<CourseSDto> Courses { get; set; } = new ObservableCollection<CourseSDto>();
    public ObservableCollection<FlashCardCategorySDto> FlashCardCategories { get; set; } = new ObservableCollection<FlashCardCategorySDto>();
    public int CoursesCount { get => Courses.Count; }
    public int FlashCardCategoriesCount { get => FlashCardCategories.Count; }
}
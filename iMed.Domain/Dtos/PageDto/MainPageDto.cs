namespace iMed.Domain.Dtos.PageDto;

public class MainPageDto
{
    public ObservableCollection<SpecialOfferSDto> SpecialOffer { get; set; } = new ObservableCollection<SpecialOfferSDto>();


    public ObservableCollection<CourseSDto> RecentCourse { get; set; } = new ObservableCollection<CourseSDto>();
    public ObservableCollection<CourseSDto> MineCourse { get; set; } = new ObservableCollection<CourseSDto>();
    public ObservableCollection<CourseSDto> PopularCourse { get; set; } = new ObservableCollection<CourseSDto>();


    public ObservableCollection<FlashCardCategorySDto> RecentFlashCards { get; set; } = new ObservableCollection<FlashCardCategorySDto>();
    public ObservableCollection<FlashCardCategorySDto> MineFlashCards { get; set; } = new ObservableCollection<FlashCardCategorySDto>();
    public ObservableCollection<FlashCardCategorySDto> PopularFlashCards { get; set; } = new ObservableCollection<FlashCardCategorySDto>();


}
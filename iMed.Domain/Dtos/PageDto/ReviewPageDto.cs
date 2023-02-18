namespace iMed.Domain.Dtos.PageDto;

public class ReviewPageDto
{
    public ObservableCollection<UserFlashCardStatusLDto> FlashCards { get; set; } = new();
}
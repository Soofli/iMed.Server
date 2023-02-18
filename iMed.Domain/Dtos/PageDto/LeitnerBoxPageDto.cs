namespace iMed.Domain.Dtos.PageDto;

public class LeitnerBoxDto : INotifyPropertyChanged
{
    public FlashCardStatus Status { get; set; }
    public bool IsSelected { get; set; }
    public int FlashCardCount { get; set; }
    public ObservableCollection<UserFlashCardStatusLDto> FlashCards { get; set; } = new();


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
public class LeitnerBoxPageDto : INotifyPropertyChanged
{
    public ObservableCollection<UserFlashCardStatusLDto> FlashCards { get; set; } = new();
    public ObservableCollection<FlashCardTagSDto> FlashCardsTag { get; set; } = new();
    public ObservableCollection<FlashCardCategorySDto> FlashCardCategories { get; set; } = new();
    public ObservableCollection<UserFlashCardStatusLDto> TodayFlashCards { get; set; } = new();
    public ObservableCollection<UserFlashCardStatusLDto> SelectedFlashCards { get; set; } = new();
    public ObservableCollection<LeitnerBoxDto> LeitnerBoxes { get; set; } = new();

    public int TotalFlashCard { get; set; }
    public int TotalTodayFlashCard { get; set; }
    public int TotalDoneFlashCard { get; set; }


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
namespace iMed.Domain.Dtos.PageDto;

public class PurchasePageDto : INotifyPropertyChanged
{
    public ObservableCollection<CourseSDto> Courses { get; set; } = new ObservableCollection<CourseSDto>();


    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
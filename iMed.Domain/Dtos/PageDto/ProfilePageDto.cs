namespace iMed.Domain.Dtos.PageDto;

public class ProfilePageDto : INotifyPropertyChanged
{
    public UserSDto User { get; set; }

    public int PurchaseCount { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
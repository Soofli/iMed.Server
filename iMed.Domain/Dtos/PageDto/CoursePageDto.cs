namespace iMed.Domain.Dtos.PageDto;

public class CoursePageDto : INotifyPropertyChanged
{
    public ObservableCollection<VideoSDto> Videos { get; set; } = new ObservableCollection<VideoSDto>();
    public ObservableCollection<CourseHandoutSDto> Handouts { get; set; } = new ObservableCollection<CourseHandoutSDto>();
    public bool IsPurchased { get; set; }
    public string CourseTime { get; set; }
    public float RateAvg { get; set; }
    public float RateCount { get; set; }
    public CourseSDto Course { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
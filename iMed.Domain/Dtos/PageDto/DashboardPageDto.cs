namespace iMed.Domain.Dtos.PageDto;
public class DashboardPageDto
{
    public int CourseCount { get; set; }
    public int FlashCardCategoryCount { get; set; }
    public List<UserSDto> LastUsers { get; set; }
    public List<PaymentSDto> LastPayments { get; set; }
}

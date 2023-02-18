namespace iMed.Domain.Enums;

public enum FlashCardStatus
{
    [Display(Name = "آرشیو شده")]
    Archived,
    [Display(Name = "جدید")]
    Step0,
    [Display(Name = "باکس 1")]
    Step1,
    [Display(Name = "باکس 2")]
    Step2,
    [Display(Name = "باکس 3")]
    Step3,
    [Display(Name = "باکس 4")]
    Step4,
    [Display(Name = "باکس 5")]
    Step5,
    [Display(Name = "باکس 6")]
    Step6,
    [Display(Name = "باکس 7")]
    Step7,
    [Display(Name = "انجام شده")]
    Done
}
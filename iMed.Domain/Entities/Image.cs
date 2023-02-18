namespace iMed.Domain.Entities;

public class Image : ApiEntity
{
    [Key]
    public int ImageId { get; set; }
    public string Name { get; set; }
    public string FileLocation { get; set; }
    public string FileName { get; set; }
}
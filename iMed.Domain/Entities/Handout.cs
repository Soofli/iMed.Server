namespace iMed.Domain.Entities;

public class Handout : ApiEntity
{
    public int HandoutId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string FileLocation { get; set; }
    public string FileName { get; set; }
}
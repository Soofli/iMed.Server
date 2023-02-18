namespace iMed.Core.Interfaces;

public interface IFileService : IScopedDependency
{
    Task ConvertVideo(string filePath);
}
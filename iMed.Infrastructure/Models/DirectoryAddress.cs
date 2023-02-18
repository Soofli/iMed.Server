
namespace iMed.Infrastructure.Models;
public static class DirectoryAddress
{
    public static string WwwRoot { get; } = $"{Directory.GetCurrentDirectory()}/wwwroot";
    public static string BackUps { get; } = $"{WwwRoot}/BackUps";
    public static string Logs { get; } = $"{WwwRoot}/Logs";
    public static string Images { get; } = $"{WwwRoot}/Images";


}
public static class FilesAddress
{
    public static string AppSettings { get; } = $"{DirectoryAddress.WwwRoot}/AppSettings.txt";
    public static string License { get; } = $"license.bin";
}


namespace iMed.Repos.Models;
public static class FilePaths
{
    public static string Videos => $"{Directory.GetCurrentDirectory()}/wwwroot/Videos";
    public static string Handouts => $"{Directory.GetCurrentDirectory()}/wwwroot/Handouts";
    public static string Images => $"{Directory.GetCurrentDirectory()}/wwwroot/Images";
    public static string IdentityImages => $"{Directory.GetCurrentDirectory()}/wwwroot/IdentityImages";
}

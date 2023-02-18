using StringExtensions = iMed.Common.Extensions.StringExtensions;

namespace iMed.Infrastructure.Services;

public class FileService : IFileService
{
    public async Task ConvertVideo(string filePath)
    {
        string output = filePath.Split('/').Last().Split('.').First();
        var type = filePath.Split('/').Last().Split('.').Last();
        output = Path.Combine($"{FilePaths.Videos}/{output + "_" + DateTime.Now.ToString("yyyyMMdd") + StringExtensions.GetId(3) + "." + type}");
        var snippet = await FFmpeg.Conversions.FromSnippet.Convert(filePath, output);
        IConversionResult result = await snippet.Start();
        File.Delete($"{filePath}");
    }
}
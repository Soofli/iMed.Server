using iMed.Core.Interfaces;

namespace iMed.Server.Controllers.V1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class FileController : ControllerBase
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IAccountService _accountService;
    private readonly IFileService _fileService;
    private readonly ILogger<FileController> _logger;

    public FileController(ICurrentUserService currentUserService,
        IRepositoryWrapper repositoryWrapper,
        IAccountService accountService,
        IFileService fileService,
        ILogger<FileController> logger)
    {
        _currentUserService = currentUserService;
        _repositoryWrapper = repositoryWrapper;
        _accountService = accountService;
        _fileService = fileService;
        _logger = logger;
        CheckDirectories();
    }
    [HttpGet, Route("Video/{name}")]
    public async Task<IActionResult> GetVideo(string name, CancellationToken cancellationToken)
    {
        var video = await _repositoryWrapper.SetRepository<Video>().TableNoTracking
            .FirstOrDefaultAsync(v => v.FileName == name, cancellationToken);
        if (video == null)
            throw new AppException("ویدیو پیدا نشد");
        var purchase = await _repositoryWrapper.SetRepository<CoursePurchase>().TableNoTracking
            .FirstOrDefaultAsync(v => v.UserId == _currentUserService.UserId.ToInt() && v.CourseId == video.CourseId, cancellationToken);
        if (purchase == null)
            throw new AppException("شما این ویدیو را خریداری نکرده اید");
        await using (FileStream fileStream = new FileStream($"{FilePaths.Videos}/{name}", FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            return File(fileStream, "APPLICATION/OCTET-STREAM");
        }
    }

    [HttpDelete, Route("Video/{name}")]
    public IActionResult DeleteVideo(string name)
    {
        if (!System.IO.File.Exists($"{FilePaths.Videos}/{name}"))
            throw new BaseApiException(ApiResultStatusCode.NotFound, "فایل مورد نظر پیدا نشد");
        System.IO.File.Delete($"{FilePaths.Videos}/{name}");
        return Ok();
    }

    [HttpGet, Route("Video"), ApiResultFilter]
    public IActionResult GetVideos()
        => Ok(Directory.GetFiles(FilePaths.Videos).OrderByDescending(o => GetDateTimeByName(o)).Select(f => new ResponseFile { Name = f.Split('/').Last(), Location = f }).ToList());

    [HttpGet, Route("IdentityImage/{name}"), AllowAnonymous]
    public async Task<IActionResult> GetIdentitiyImage(string name)
        => await GetFileStreamResultAsync($"{FilePaths.IdentityImages}/{name}", "image/jpeg");

    [HttpGet, Route("Image/{name}"), AllowAnonymous]
    public async Task<IActionResult> GetImage(string name)
        => await GetFileStreamResultAsync($"{FilePaths.Images}/{name}", "image/jpeg");

    [HttpDelete, Route("Image/{name}")]
    public IActionResult DeleteImage(string name)
    {
        if (!System.IO.File.Exists($"{FilePaths.Images}/{name}"))
            throw new BaseApiException(ApiResultStatusCode.NotFound, "فایل مورد نظر پیدا نشد");
        System.IO.File.Delete($"{FilePaths.Images}/{name}");
        return Ok();
    }

    [HttpGet, Route("Image"), ApiResultFilter]
    public IActionResult GetImages()
        => Ok(Directory.GetFiles(FilePaths.Images).OrderByDescending(o => GetDateTimeByName(o)).Select(f => new ResponseFile { Name = f.Split('/').Last(), Location = f }).ToList());

    DateTime GetDateTimeByName(string name)
    {
        try
        {
            name = name.Split('/').Last();
            var date = name.Split('_').Last().Split('.').First();
            if (date.Count() < 8)
                return DateTime.MinValue;
            if (int.TryParse(date.Substring(0, 4), out int year) && int.TryParse(date.Substring(4, 2), out int month) && int.TryParse(date.Substring(6, 2), out int day))
                return new DateTime(year, month, day);
            else
                return DateTime.MinValue;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            return DateTime.MinValue;
        }
    }

    [HttpGet, Route("Handout/{name}"), AllowAnonymous]
    public async Task<IActionResult> GetHandout(string name)
        => await GetFileStreamResultAsync($"{FilePaths.Handouts}/{name}", "document/pdf");

    [HttpDelete, Route("Handout/{name}")]
    public IActionResult DeleteHandout(string name)
    {
        if (!System.IO.File.Exists($"{FilePaths.Handouts}/{name}"))
            throw new BaseApiException(ApiResultStatusCode.NotFound, "فایل مورد نظر پیدا نشد");
        System.IO.File.Delete($"{FilePaths.Handouts}/{name}");
        return Ok();
    }

    [HttpGet, Route("Handout"), ApiResultFilter]
    public IActionResult GetHandouts()
        => Ok(Directory.GetFiles(FilePaths.Handouts).OrderByDescending(o => GetDateTimeByName(o)).Select(f => new ResponseFile { Name = f.Split('/').Last(), Location = f }).ToList());

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    [HttpPost, Route("[action]"), RequestSizeLimit(350000000), ApiResultFilter, RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
    public async Task<IActionResult> UploadVideo(IFormFile file)
    {
        CheckDirectories();
        string url;
        var type = file.FileName.Split('.').Last();
        string name = file.FileName.Split('.').First();
        name = name.Replace(" ", "_");
        name = name + "_" + DateTime.Now.ToString("yyyyMMdd") + "." + type;

        string filePathBase = Path.Combine($"{FilePaths.Videos}/{name}");
        url = $"/Videos/{name}";
        await using (var stream = new FileStream(filePathBase, FileMode.Create))
            await file.CopyToAsync(stream);
        var image = new ResponseFile
        {
            Location = filePathBase,
            Name = name,
            Url = url
        };
        return Ok(image);

    }


    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    [HttpPost, Route("[action]"), RequestSizeLimit(100000000), ApiResultFilter]
    public async Task<IActionResult> UploadImage([FromBody] FileUploadRequest fileUploadRequest)
    {
        CheckDirectories();
        string url;
        var type = fileUploadRequest.FileName.Split('.').Last();
        var name = fileUploadRequest.FileName.Split('.').First();
        name = name.Replace(" ", "_");
        fileUploadRequest.FileName = name + "_" + DateTime.Now.ToString("yyyyMMdd") + "." + type;

        string filePathBase = Path.Combine($"{FilePaths.Images}/{fileUploadRequest.FileName}");
        url = $"/Images/{fileUploadRequest.FileName}";

        byte[] Byte = Convert.FromBase64String(fileUploadRequest.StringBaseFile);
        await System.IO.File.WriteAllBytesAsync(filePathBase, Byte);
        var image = new ResponseFile
        {
            Location = filePathBase,
            Name = fileUploadRequest.FileName,
            Url = url
        };
        return Ok(image);

    }

    [HttpPost, Route("[action]"), RequestSizeLimit(100000000), ApiResultFilter]
    public async Task<IActionResult> UploadIdentityImage([FromBody] FileUploadRequest fileUploadRequest)
    {
        CheckDirectories();
        string url;
        var type = fileUploadRequest.FileName.Split('.').Last();
        var name = fileUploadRequest.FileName.Split('.').First();
        fileUploadRequest.FileName = _currentUserService.UserName + "_IdentityImage_" + name + "_" + DateTime.Now.ToString("yyyyMMdd") + "." + type;

        string filePathBase = Path.Combine($"{FilePaths.IdentityImages}/{fileUploadRequest.FileName}");
        url = $"/Images/{fileUploadRequest.FileName}";

        byte[] Byte = Convert.FromBase64String(fileUploadRequest.StringBaseFile);
        await System.IO.File.WriteAllBytesAsync(filePathBase, Byte);
        var image = new ResponseFile
        {
            Location = filePathBase,
            Name = fileUploadRequest.FileName,
            Url = url
        };
        await _accountService.AddIdentityImageAsync(image);
        return Ok(image);

    }


    [HttpPost, Route("[action]"), RequestSizeLimit(100000000), ApiResultFilter]
    public async Task<IActionResult> UploadHandout(IFormFile file)
    {
        CheckDirectories();
        string url;
        var type = file.FileName.Split('.').Last();
        string name = file.FileName.Split('.').First();
        name = name.Replace(" ", "_");
        name = name + "_" + DateTime.Now.ToString("yyyyMMdd") + "." + type;

        string filePathBase = Path.Combine($"{FilePaths.Handouts}/{name}");
        url = $"/Handouts/{name}";
        await using (var stream = new FileStream(filePathBase, FileMode.Create))
            await file.CopyToAsync(stream);
        var image = new ResponseFile
        {
            Location = filePathBase,
            Name = name,
            Url = url
        };
        return Ok(image);

    }

    private async Task<FileStreamResult> GetFileStreamResultAsync(string path, string format)
    {
        var memory = new MemoryStream();
        using (var stream = new FileStream(path, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }

        memory.Position = 0;
        return new FileStreamResult(memory, format);
    }

    private void CheckDirectories()
    {
        if (!Directory.Exists(FilePaths.Handouts))
            Directory.CreateDirectory(FilePaths.Handouts);
        if (!Directory.Exists(FilePaths.Videos))
            Directory.CreateDirectory(FilePaths.Videos);
        if (!Directory.Exists(FilePaths.Images))
            Directory.CreateDirectory(FilePaths.Images);
        if (!Directory.Exists(FilePaths.IdentityImages))
            Directory.CreateDirectory(FilePaths.IdentityImages);
    }
}
namespace app.Services;

public class FileUploadService(IWebHostEnvironment env) : IFileUploadService
{
    public async Task<string> UploadAsync(Stream fileStream, string fileName, long maxSize = 10 * 1024 * 1024)
    {
        var uploadsDir = Path.Combine(env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsDir);

        var extension = Path.GetExtension(fileName);
        var uniqueName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(uploadsDir, uniqueName);

        await using var fs = new FileStream(filePath, FileMode.Create);
        await fileStream.CopyToAsync(fs);

        return $"/uploads/{uniqueName}";
    }

    public async Task<string> UploadAsync(ReadOnlyMemory<byte> data, string fileName)
    {
        var uploadsDir = Path.Combine(env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsDir);

        var extension = Path.GetExtension(fileName);
        var uniqueName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(uploadsDir, uniqueName);

        await File.WriteAllBytesAsync(filePath, data.ToArray());

        return $"/uploads/{uniqueName}";
    }
}

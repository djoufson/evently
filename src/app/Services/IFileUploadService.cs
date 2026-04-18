namespace app.Services;

public interface IFileUploadService
{
    Task<string> UploadAsync(Stream fileStream, string fileName, long maxSize = 10 * 1024 * 1024);
    Task<string> UploadAsync(ReadOnlyMemory<byte> data, string fileName);
}

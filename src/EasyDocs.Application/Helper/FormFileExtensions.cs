using Microsoft.AspNetCore.Http;

namespace EasyDocs.Application.Helper;

public static class FormFileExtensions
{
    public static byte[]? GetBytes(this IFormFile? formFile)
    {
        if(formFile == null) return Array.Empty<byte>();

        using var memoryStream = new MemoryStream();
        formFile.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}
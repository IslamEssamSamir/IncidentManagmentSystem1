using IncidentManagmentSystem1.API.Core.Enums;

namespace IncidentManagmentSystem1.API.Services.Interfaces;

public interface IFileServices
{
   Task<(bool isUploaded, string? errorMessage, string? filePath)> UploadAsync(IFormFile file, string folderPath, string? fileName = null, FileType? fileType = FileType.Image);

    public void Delete(string filePath);
}

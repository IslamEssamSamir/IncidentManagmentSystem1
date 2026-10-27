using IncidentManagmentSystem1.API.Core.DTOs.GenericDTOs;
using IncidentManagmentSystem1.API.Core.Enums;
using IncidentManagmentSystem1.API.Services.Interfaces;

namespace IncidentManagmentSystem1.API.Services.Implementations;

public class FileServices(IWebHostEnvironment webHostEnvironment) : IFileServices
{
    
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;


    public List<string> _allowedDocumentExtensions = new(){".pdf",".doc",".docx",".docm",".odt",".rtf",".txt"};
    public List<string> _allowedImageExtensions = new(){ ".jpg", ".jpeg", ".png", ".webp" };

    public int _allowedImageSize = 2097152; // 2Mbytes
    public int _allowedFileSize = 10485760; // 10Mbytes



    public async Task<(bool isUploaded, string? errorMessage, string? filePath)> UploadAsync(IFormFile file, string folderPath, string? fileName = null, FileType? fileType = FileType.Image)
    {

        var extension = Path.GetExtension(file.FileName);

        switch (fileType)
        {
            case FileType.Image:
                if (!_allowedImageExtensions.Contains(extension))
                    return (isUploaded: false, errorMessage: ValidationErrors.NotAllowedImageExtensions, filePath: null);

                if (file.Length > _allowedImageSize)
                    return (isUploaded: false, errorMessage: ValidationErrors.MaxAllowedImageSize, filePath: null);

                break;

            case FileType.Documentation:
                if (!_allowedDocumentExtensions.Contains(extension))
                    return (isUploaded: false, errorMessage: ValidationErrors.NotAllowedDocumentExtensions, filePath: null);

                if (file.Length > _allowedFileSize)
                    return (isUploaded: false, errorMessage: ValidationErrors.MaxAllowedDocumentSize, filePath: null);

                break;

            default:
                return (isUploaded: false, errorMessage: "Error in File Type", filePath: null);
        }


        string physicalFileName = (fileName ?? Guid.NewGuid().ToString()) + extension;
        string physicalFilePath = Path.Combine(folderPath, physicalFileName);

        string physicalFileFullPath = Path.Combine(_webHostEnvironment.WebRootPath, physicalFilePath);



        FileStream fileStream = new FileStream(physicalFileFullPath, FileMode.Create);
        await file.CopyToAsync(fileStream);
        fileStream.Dispose();


        return (isUploaded: true, errorMessage: null, filePath: physicalFilePath);

    }

    public void Delete(string filePath)
    {
        string fullFilePath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
        if (File.Exists(fullFilePath))
            File.Delete(fullFilePath);

    }
}

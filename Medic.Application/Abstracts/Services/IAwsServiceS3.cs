using Microsoft.AspNetCore.Http;

namespace Medic.Services.Abstracts.Services;

public interface IAwsServiceS3
{
    Task<string> UploadFile(IFormFile formFile);
}
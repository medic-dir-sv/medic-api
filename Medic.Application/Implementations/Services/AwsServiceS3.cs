using Amazon.S3;
using Amazon.S3.Model;
using Medic.Services.Abstracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Medic.Services.Implementations.Services;

public class AwsServiceS3 : IAwsServiceS3
{
    private readonly IAmazonS3 _s3Client;
    private readonly IConfiguration _env;

    public AwsServiceS3(IAmazonS3 s3Client, IConfiguration env)
    {
        _s3Client = s3Client;
        _env = env;
    }

    public async Task<string> UploadFile(IFormFile formFile)
    {
        var location = $"uploads/{DateTime.UtcNow:yyyy-mm-dd_hh:mm:ss:ms}-{formFile.FileName}";

        await using var stream = formFile.OpenReadStream();

        var putRequest = new PutObjectRequest()
        {
            Key = location,
            BucketName = _env["Aws:Bucket"],
            InputStream = stream,
            AutoCloseStream = true,
            ContentType = formFile.ContentType,
            CannedACL = S3CannedACL.PublicRead
        };

        await _s3Client.PutObjectAsync(putRequest);
        return $"{_env["Aws:Location"]}/{location}";
    }
}
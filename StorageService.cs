using Google.Cloud.Storage.V1;

namespace InFeminine_Web_API
{
    public class StorageService
    {
        private readonly IConfiguration _config;
        private readonly UrlSigner _signer;
        private readonly string _bucketName;

        public StorageService(IConfiguration config)
        {
            _config = config;
            _bucketName = _config["GoogleCloud:BucketName"];
            var credentialsPath = _config["GoogleCloud:CredentialsPath"];
            _signer = UrlSigner.FromServiceAccountPath(credentialsPath);
        }

        public string GenerateUploadUrl(string objectName, int durationMinutes = 15)
        {
            var options = TimeSpan.FromMinutes(durationMinutes);

            return _signer.Sign(_bucketName, objectName, options);
        }

        public string GenerateDownloadUrl(string objectName, int durationMinutes = 15)
        {
            return _signer.Sign(
                _bucketName,
                objectName,
                TimeSpan.FromMinutes(durationMinutes),
                HttpMethod.Get
            );
        }
    }
}

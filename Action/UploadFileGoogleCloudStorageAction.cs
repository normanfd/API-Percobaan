using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Action
{
    public class UploadFileGoogleCloudStorageAction
    {
        private readonly StorageClient _storageClient;
        private readonly string _bucketName;
        public UploadFileGoogleCloudStorageAction()
        {
            var credentialFilePath = @"C:\Users\nfd96\Desktop\GoogleClouStorageConfig\config.json";
            var googleCredential = GoogleCredential.FromFile(credentialFilePath);
            _storageClient = StorageClient.Create(googleCredential);
            _bucketName = "lead-centralization-dev";
        }
        public async Task UploadFileAsync(byte[] content, string filename)
        {
            using var memoryStream = new MemoryStream(content);
            await _storageClient.UploadObjectAsync(_bucketName, filename, null, memoryStream);
        }
        public string GetUrlSigned()
        {
            var credentialFilePath = @"C:\Users\nfd96\Desktop\GoogleClouStorageConfig\config.json";
            UrlSigner urlSigner = UrlSigner.FromServiceAccountPath(credentialFilePath);
            // V4 is the default signing version.
            var objectName = "cobadtiga.jpg";
            string url = urlSigner.Sign(_bucketName, objectName, TimeSpan.FromHours(1), HttpMethod.Get);
            Console.WriteLine("Generated GET signed URL:");
            Console.WriteLine(url);
            Console.WriteLine("You can use this URL with any user agent, for example:");
            Console.WriteLine($"curl '{url}'");
            return url;
        }
        public async Task<MemoryStream> GetFileStreamAsync(string filename)
        {
            try
            {
                var stream = new MemoryStream();
                await _storageClient.DownloadObjectAsync(_bucketName, filename, stream);

                stream.Seek(0, SeekOrigin.Begin);

                return stream;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, string.Format("Download file '{0}' from Google Cloud Storage failed.", filename));
                return null;
            }
        }
    }
}

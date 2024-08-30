using Azure.Storage.Blobs;

namespace AzuriteStorage
{
    public class BlobService : IStorageService
    {
        public async Task Execute()
        {
            var connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;";

            var client = new BlobContainerClient(connectionString, "images");

            var stream = await new HttpClient().GetStreamAsync("https://www.element61.be/sites/default/files/img_competences/Azure%2520Blob%2520Storage.png");

            var blob = client.GetBlobClient("AzureBlobStorage.png");
            await blob.UploadAsync(stream);

            Console.WriteLine($"Image {blob.Name} was uploaded successfully!");
        }
    }
}

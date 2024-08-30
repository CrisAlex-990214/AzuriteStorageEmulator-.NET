using Azure.Data.Tables;

namespace AzuriteStorage
{
    public class TableService : IStorageService
    {
        public Task Execute()
        {
            var connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";

            var client = new TableClient(connectionString, "product");

            List<TableEntity> entities = [
                    new("Clothing", "1") { { "name", "T-shirt" }, { "price", 44.56M }, { "quantity", 3 } },
                    new("Clothing", "2") { { "name", "Jacket" }, { "price", 9.74M }, { "quantity", 2 } }
                ];

            entities.ForEach(async e =>
            {
                await client.AddEntityAsync(e);
                Console.WriteLine($"{e["name"]} added to the product table.");
            });

            return Task.CompletedTask;
        }
    }
}

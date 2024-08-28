// See https://aka.ms/new-console-template for more information

using AzuriteStorage;

List<IStorageService> storageServices = [
        new BlobService(),
        new QueueService(),
        new TableService()
    ];

var storageTasks = storageServices.Select(x => x.Execute());
await Task.WhenAll(storageTasks);

Console.ReadKey();


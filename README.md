This sample code is going to show how to create a database, collection & documents in Azure Cosmos DB

Solution has built on Visual Studio 2017 on .NET Core 2.0

You can see code snippet to create the database, collection and document using Azure Cosmos DB SDK

You can go through this article and check how to trigger changes on Cosmos DB and execute an action using a Azure Function app, https://social.technet.microsoft.com/wiki/contents/articles/50897.create-a-trigger-on-azure-cosmos-db-using-a-function-app.aspx 


        public async static Task CreateDatabase (string database)
        {
            var db = await client.CreateDatabaseIfNotExistsAsync(new Database { Id = database});
        }

        public async static Task CreateCollection(string database, string collection)
        {

            var databasecollection = await client.CreateDocumentCollectionIfNotExistsAsync(
            UriFactory.CreateDatabaseUri(database), new DocumentCollection { Id = collection });
        }

        public async static Task CreateDocument (string database, string collection, VehicleSpeed vehicleSpeed)
        {

            await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(database, collection),
            vehicleSpeed);
          
        }

        public async static Task CreateMultipleDocument(string database, string collection)
        {
            int documentCount = 500;
            for (int i = 0; i < documentCount; i++)
            {
                double speed = new Random().NextDouble() * 100;
                VehicleSpeed vehicleSpeed = new VehicleSpeed { VehicleNumber = "KJ -7788", City = "Colombo", Speed = speed};
                await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(database, collection), vehicleSpeed);
            }
        }

        private async static Task DeleteDocuments (string database, string collection)
        {
            await client.DeleteDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(database, collection));
        }

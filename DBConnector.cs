using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace highwaytraffic
{
    static class DBConnector
    {

        static DocumentClient client;
     
        public async static Task Create ()
        {
            try
            {

                string endPointUrl = "https://highwaytraffic.documents.azure.com:443/";
                string primaryKey = "jSuZYTAvpOiw65P1O1TEPD7pAmjTTDUd5I9pudCkABUz97f3fxcnjg259o7jqDNCJXDyRAQrjOm6H2k24ZjyrQ==";

                string databaseName = "trafficdata";

                string databaseCollection = "vehiclespeed";

                client = new DocumentClient(new Uri(endPointUrl), primaryKey);

                await CreateDatabase(databaseName);

                await CreateCollection(databaseName, databaseCollection);

                //VehicleSpeed vehicleSpeed = new VehicleSpeed { VehicleNumber = "KJ -7788", City = "Colombo", Speed = 112.78 };
                VehicleSpeed vehicleSpeed = new VehicleSpeed { VehicleNumber = "KJ -7788", City = "Colombo", Speed = 70.78 };

                await CreateDocument(databaseName, databaseCollection, vehicleSpeed);

                //await CreateMultipleDocument(databaseName, databaseCollection);
                //await DeleteDocuments(databaseName, databaseCollection);
            }

            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }

            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
        }

        public async static Task CreateDatabase (string database)
        {
            var db = await client.CreateDatabaseIfNotExistsAsync(new Database { Id = database});
        }

        public async static Task CreateCollection(string database, string collection)
        {

            var databasecollection = await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(database),
                new DocumentCollection { Id = collection });
        }

        public async static Task CreateDocument (string database, string collection, VehicleSpeed vehicleSpeed)
        {

            await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(database, collection), vehicleSpeed);
          
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

    }
}

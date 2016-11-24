using FabrikaFood.Abstractions;
using Microsoft.WindowsAzure.MobileServices;
using System;

namespace FabrikaFood.Services
{
    public class AzureCloudService : ICloudService
    {
        MobileServiceClient client;

        public AzureCloudService()
        {
            client = new MobileServiceClient("http://fabrikafood.azurewebsites.net");
        }

        public ICloudTable<T> GetTable<T>() where T : TableData => new AzureCloudTable<T>(client);

        public Uri ServiceBaseUri
        {
            get { return client.MobileAppUri; }
        }

        public MobileServiceUser CurrentUser
        {
            get { return client.CurrentUser; }
            set { client.CurrentUser = value; }
        }
    }
}

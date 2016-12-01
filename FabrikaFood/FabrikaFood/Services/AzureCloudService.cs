using FabrikaFood.Abstractions;
using Microsoft.WindowsAzure.MobileServices;
using System;

namespace FabrikaFood.Services
{
    //The Main manager class user to talk to the backend via MobileServiceClient.
    public class AzureCloudService : ICloudService
    {
        public MobileServiceClient client;
        //The client is the connection to the Azure Mobile App Backend.

        public AzureCloudService()
        {
            client = new MobileServiceClient("https://fabrikafood.azurewebsites.net");
        }

        //Generic method to get any table from the database using an instance of the AzureCloudTable Class.
        public ICloudTable<T> GetTable<T>() where T : TableData => new AzureCloudTable<T>(client);

        public Uri ServiceBaseUri
        {
            get { return client.MobileAppUri; }
        }

        //Keeps track of the current logged in user.
        public MobileServiceUser CurrentUser
        {
            get { return client.CurrentUser; }
            set { client.CurrentUser = value; }
        }
    }
}

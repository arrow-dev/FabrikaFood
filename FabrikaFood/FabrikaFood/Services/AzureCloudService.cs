﻿using FabrikaFood.Abstractions;
using Microsoft.WindowsAzure.MobileServices;

namespace FabrikaFood.Services
{
    public class AzureCloudService : ICloudService
    {
        MobileServiceClient client;

        public AzureCloudService()
        {
            client = new MobileServiceClient("http://fabrikafood.azurewebsites.net");
        }

        public ICloudTable<T> GetTable<T>() where T : TableData
        {

            return new AzureCloudTable<T>(client);
        }
    }
}

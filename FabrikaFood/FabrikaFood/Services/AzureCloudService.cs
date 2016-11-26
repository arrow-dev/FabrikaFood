using FabrikaFood.Abstractions;
using FabrikaFood.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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


        public async Task<ICollection<Comment>> GetComments(string menuItemId)
        {
            return await client.GetTable<Comment>().Where(c => c.MenuItemId == menuItemId).ToListAsync();
        }

        public async Task PostComment(Comment comment)
        {
            await client.GetTable<Comment>().InsertAsync(comment);
        }
    }
}

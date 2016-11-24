using Microsoft.WindowsAzure.MobileServices;

namespace FabrikaFood.Abstractions
{
    public interface ICloudService
    {
        ICloudTable<T> GetTable<T>() where T : TableData;
        MobileServiceUser CurrentUser { get; set; }
    }
}

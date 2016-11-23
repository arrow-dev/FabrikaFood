using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace FabrikaFood.Abstractions
{
    public interface ILoginProvider
    {
        Task LoginAsync(MobileServiceClient client);
    }
}

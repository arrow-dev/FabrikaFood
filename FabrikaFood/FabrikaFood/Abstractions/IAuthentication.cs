using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace FabrikaFood.Abstractions
{
    public interface IAuthentication
    {
        Task<MobileServiceUser> LoginAsync(MobileServiceClient client, MobileServiceAuthenticationProvider provider);
    }
}

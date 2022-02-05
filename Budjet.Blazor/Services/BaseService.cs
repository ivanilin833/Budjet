using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace Budjet.Blazor.Services
{
    public class BaseService: ComponentBase
    {
        private readonly AuthenticationStateProvider _authState;

        public BaseService(AuthenticationStateProvider authState) => _authState = authState;

        public async Task<string> GetUserId()
        {
            var user = (await _authState.GetAuthenticationStateAsync()).User;
            var UserId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return UserId;
        }
    }
}

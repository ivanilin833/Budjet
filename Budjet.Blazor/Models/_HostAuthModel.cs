using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Budjet.Blazor.Models
{
    public class _HostAuthModel : PageModel
    {
        public IActionResult OnGetLogin()
        {
            return Challenge(AuthProps(), "oidc");
        }

        public async Task OnGetLogout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc", AuthProps());
        }

        private AuthenticationProperties AuthProps()
            => new AuthenticationProperties
            {
                RedirectUri = Url.Content("~/")
            };
    }
}

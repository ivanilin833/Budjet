using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Budjet.Identity
{
    public class Configurations
    {
        public static IEnumerable<ApiScope> ApiScopes =>
           new List<ApiScope>
           {
                new ApiScope("NotesWebAPI", "Web API")
           };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("NotesWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = {"NotesWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "BlazorID_App",
                    ClientName="Blazor Server App - Identity Claims",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,
                    RedirectUris = { "https://localhost:44378/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44378/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "NotesWebAPI"
                    }
                }
            };
    }
}

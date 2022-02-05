using Budjet.Blazor.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Budjet.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CRUDService>();
            services.AddScoped<ResultService>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
          .AddCookie("Cookies")
          .AddOpenIdConnect("oidc", options =>
          {
              options.Authority = "https://localhost:44395/";
              options.ClientId = "BlazorID_App"; 
              options.ResponseType = "code";
              options.SaveTokens = true;
              options.GetClaimsFromUserInfoEndpoint = true;
              options.Events = new OpenIdConnectEvents
              {
                    OnAccessDenied = context =>
                  {
                      context.HandleResponse();
                      context.Response.Redirect("/");
                      return Task.CompletedTask;
                  }
              };
          });
            services.AddMvcCore();
            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

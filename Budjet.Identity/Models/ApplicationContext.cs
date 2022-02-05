using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Budjet.Identity.Models
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
        {
            public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }
        }
    
}

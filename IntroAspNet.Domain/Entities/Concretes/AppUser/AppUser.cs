using Microsoft.AspNetCore.Identity;

namespace IntroAspNet.Domain.Entities.Concretes.AppUser
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

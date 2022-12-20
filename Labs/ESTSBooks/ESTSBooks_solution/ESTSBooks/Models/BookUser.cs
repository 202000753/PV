using Microsoft.AspNetCore.Identity;

namespace ESTSBooks.Models
{
    public class BookUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Entities
{
    public class User : IdentityUser
    {
        public string TelegramId { get; set; }
        public string TelegramLogin { get; set; }
    }
}

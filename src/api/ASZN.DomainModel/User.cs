using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASZN.DomainModel
{
    public class User : IdentityUser<int>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }


        public DateTimeOffset LastLoginAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastPasswordChangedAt { get; set; }

        public IList<Account> Accounts { get; set; }
    }
}
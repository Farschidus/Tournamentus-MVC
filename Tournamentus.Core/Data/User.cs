using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data.Identity
{
    public class User : IdentityUser<int>
    {
        public const int FirstNameMaxLength = 16;
        public const int LastNameMaxLength = 32;

        [Required, MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; }
        [Required, MaxLength(LastNameMaxLength)]
        public string LastName { get; set; }
    }
}

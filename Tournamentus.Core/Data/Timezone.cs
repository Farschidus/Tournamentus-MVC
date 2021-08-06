using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    // Timezones
    public class Timezone
    {
        public const int TimezoneIdMaxLength = 50;
        public const int DisplayNameMaxLength = 100;

        [Key, Required, MaxLength(TimezoneIdMaxLength)]
        public string TimezoneId { get; set; }
        [Required]
        public int BaseUtcOffsetInMinutes { get; set; }
        [MaxLength(DisplayNameMaxLength)]
        public string DisplayName { get; set; }
    }
}

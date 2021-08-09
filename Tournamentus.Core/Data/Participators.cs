using Tournamentus.Core.Data.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    public class Participator
    {
        public const int TimezoneIdMaxLength = 50;

        [Key, Required, Column(Order = 0)]
        public int ParticipatorUserId { get; set; }
        [Required, Column(Order = 1)]
        public int ParticipatorTournamentId { get; set; }
        [Required, MaxLength(TimezoneIdMaxLength)]
        public string ParticipatorTimezone { get; set; }

        // Foreign keys
        [ForeignKey("ParticipatorUserId")]
        public virtual User User { get; set; }
        [ForeignKey("ParticipatorTournamentId")]
        public virtual Tournament Tournament { get; set; }
        [ForeignKey("ParticipatorTimezone")]
        public virtual Timezone Timezone { get; set; }
    }
}


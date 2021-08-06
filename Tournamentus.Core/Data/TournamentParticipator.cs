using Tournamentus.Core.Data.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    public class TournamentParticipator
    {
        public const int TimezoneIdMaxLength = 50;

        [Column(Order = 0)]
        public int UserId { get; set; }
        [Column(Order = 1)]
        public int TournamentId { get; set; }
        [MaxLength(TimezoneIdMaxLength)]
        public string TimezoneId { get; set; }

        // Foreign keys
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("TournamentId")]
        public virtual Tournament Tournament { get; set; }
        [ForeignKey("TimezoneId")]
        public virtual Timezone Timezone { get; set; }
    }
}


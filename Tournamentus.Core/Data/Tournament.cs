using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    // Tournaments
    public class Tournament
    {
        public const int TitleMaxLength = 128;
        public const int TypeMaxLength = 50;
        public const int FederationMaxLength = 50;

        [Key]
        public int TournamentId { get; set; }
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }
        [Column("Type"), Required, MaxLength(TypeMaxLength)]
        public string TypeTitle { get; set; }
        [Column("Federation"), Required, MaxLength(FederationMaxLength)]
        public string FederationName { get; set; }
        public bool IsActive { get; set; }

        // Reverse navigation
        /// <summary>
        /// Child TournamentParticipators where [TournamentParticipators].[TournamentId] point to this entity (FK_TournamentParticipators_Tournaments)
        /// </summary>
        public virtual ICollection<Participator> TournamentParticipators { get; set; }
        /// <summary>
        /// Child TournamentTeams where [TournamentTeams].[TournamentId] point to this entity (FK_TournamentTeams_Tournoments)
        /// </summary>
        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }

        // Foreign keys
        /// <summary>
        /// Parent Type pointed by [Tournaments].([Type]) (FK_Tournaments_Types)
        /// </summary>
        [ForeignKey("TypeTitle")]
        public virtual Type Type { get; set; }
        /// <summary>
        /// Parent Type pointed by [Tournaments].([Federation]) (FK_Tournaments_Federations)
        /// </summary>
        [ForeignKey("FederationName")]
        public virtual Federation Federation { get; set; }
    }
}

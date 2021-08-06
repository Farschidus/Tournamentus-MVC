using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournamentus.Core.Data
{
    // TournamentTeams
    public class TournamentTeam
    {
        public const int TeamMaxLength = 50;

        public int TournamentTeamId { get; set; }

        public int TournamentId { get; set; }

        [StringLength(TeamMaxLength)]
        public string Team { get; set; }

        // Reverse navigation
        /// <summary>
        /// Child TournamentTeamGroups where [TournamentTeamGroups].[TournamentTeamId] point to this entity (FK_TournamentTeamGroups_TournamentTeams)
        /// </summary>
        public virtual ICollection<TournamentTeamGroup> TournamentTeamGroups { get; set; }

        // Foreign keys
        /// <summary>
        /// Parent Team pointed by [TournamentTeams].([Team]) (FK_TournamentTeams_Teams)
        /// </summary>
        public virtual Team Team_Team { get; set; }
        /// <summary>
        /// Parent Tournament pointed by [TournamentTeams].([TournamentId]) (FK_TournamentTeams_Tournoments)
        /// </summary>
        public virtual Tournament Tournament { get; set; }
    }
}

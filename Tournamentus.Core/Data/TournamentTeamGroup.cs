using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    // TournamentTeamGroups
    public class TournamentTeamGroup
    {
        public const int GroupMaxLength = 50;

        [Required]
        public int TournamentTeamId { get; set; }
        [Required, MaxLength(GroupMaxLength)]
        public string Group { get; set; }
        public byte Play { get; set; }
        public byte Wins { get; set; }
        public byte Drwas { get; set; }
        public byte Losses { get; set; }
        public byte GoalsFor { get; set; }
        public byte GoalsAgainst { get; set; }
        public byte GoalDiff { get; set; }
        public byte Points { get; set; }

        // Foreign keys
        /// <summary>
        /// Parent TournamentTeam pointed by [TournamentTeamGroups].([TournamentTeamId]) (FK_TournamentTeamGroups_TournamentTeams)
        /// </summary>
        [ForeignKey("TournamentTeamId")]
        public virtual TournamentTeam TournamentTeam { get; set; }
    }
}

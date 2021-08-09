using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public class Game
    {
        public const int StageMaxLength = 50;
        public const int ResultMaxLength = 50;
        public const int PenaltyScoreMaxLength = 50;
        public const int TimezoneIdMaxLength = 50;

        [Key]
        public int GameId { get; set; }
        [Required]
        public int TournamentTeamIdA { get; set; }
        [Required]
        public int TournamentTeamIdB { get; set; }
        [Required, MaxLength(StageMaxLength)]
        public string Stage { get; set; }
        public int Winner { get; set; }
        public bool IsEqual { get; set; }
        [MaxLength(ResultMaxLength)]
        public string Result { get; set; }
        public bool InPenalty { get; set; }
        [MaxLength(PenaltyScoreMaxLength)]
        public string PenaltyScore { get; set; }
        public DateTimeOffset GameDateTime { get; set; }
        [MaxLength(TimezoneIdMaxLength)]
        public string TimezoneId { get; set; }

        // Reverse navigation
        /// <summary>
        /// Child UserPredicts where [UserPredicts].[Game] point to this entity (FK_UserPredicts_Games)
        /// </summary>
        public virtual ICollection<ParticipatorPredict> ParticipatorPredict { get; set; }

        // Foreign keys
        [ForeignKey("TournamentTeamIdA")]
        public virtual TournamentTeam TournamentTeamA { get; set; }
        [ForeignKey("TournamentTeamIdB")]
        public virtual TournamentTeam TournamentTeamB { get; set; }
        [ForeignKey("Stage")]
        public virtual Stage GamesStage { get; set; }
        [ForeignKey("Winner")]
        public virtual TournamentTeam WinnerTeam { get; set; }
        [ForeignKey("TimezoneId")]
        public virtual Timezone Timezone { get; set; }
    }
}

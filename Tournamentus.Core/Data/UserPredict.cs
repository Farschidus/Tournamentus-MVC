using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    // UserPredicts
    public class UserPredict
    {
        public const int PredictMaxLength = 50;

        [Key, Required]
        public int UserId { get; set; }
        [Key, Required]
        public int TournamentId { get; set; }
        [Key, Required]
        public int GameId { get; set; }
        [MaxLength(PredictMaxLength)]
        public string Predict { get; set; }
        [Column("PredictScore")]
        public byte? Score { get; set; }

        // Foreign keys
        /// <summary>
        /// Parent PredictScore pointed by [UserPredicts].([PredictScore]) (FK_UserPredicts_PredictScores)
        /// </summary>
        [ForeignKey("Score")]
        public virtual PredictScore PredictScore { get; set; }
        /// <summary>
        /// Parent TournamentParticipator pointed by [UserPredicts].([UserId], [TournamentId]) (FK_UserPredicts_TournamentParticipators)
        /// </summary>
        public virtual TournamentParticipator TournamentParticipator { get; set; }
        /// <summary>
        /// Parent TournamentParticipator pointed by [UserPredicts].([UserId], [TournamentId]) (FK_UserPredicts_TournamentParticipators)
        /// </summary>
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}

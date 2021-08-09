using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    // UserPredicts
    public class ParticipatorPredict
    {
        public const int PredictMaxLength = 50;

        [Key, Required, Column(Order = 0)]
        public int ParticipatorUserId { get; set; }
        [Key, Required, Column(Order = 1)]
        public int ParticipatorTournamentId { get; set; }
        [Key, Required, Column(Order = 2)]
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
        public virtual Participator Participator { get; set; }
        /// <summary>
        /// Parent TournamentParticipator pointed by [UserPredicts].([UserId], [TournamentId]) (FK_UserPredicts_TournamentParticipators)
        /// </summary>
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
    }
}

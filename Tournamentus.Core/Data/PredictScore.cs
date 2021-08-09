using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public class PredictScore
    {
        public const int TitleMaxLength = 50;
        public const int DescriptionMaxLength = 100;

        [Key, Required, Column("PredictScore")]
        public byte Score { get; set; }
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        // Reverse navigation
        /// <summary>
        /// Child UserPredicts where [UserPredicts].[PredictScore] point to this entity (FK_UserPredicts_PredictScore)
        /// </summary>
        public virtual ICollection<ParticipatorPredict> UserPredicts { get; set; }
    }
}

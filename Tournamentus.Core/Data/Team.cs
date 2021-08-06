using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public class Team
    {
        public const int TeamMaxLength = 50;
        public const int AbbrMaxLength = 20;
        public const int TypeMaxLength = 50;
        public const int FederationMaxLength = 50;

        [Key, Column("Team"), Required, MaxLength(TeamMaxLength)]
        public string TeamName { get; set; }
        [Required, MaxLength(AbbrMaxLength)]
        public string Abbr { get; set; }
        [Column("Type"), Required, MaxLength(TypeMaxLength)]
        public string TypeTitle { get; set; }
        [Column("Federation"), Required, MaxLength(FederationMaxLength)]
        public string FederationName { get; set; }

        // Reverse navigation
        /// <summary>
        /// Child TournamentTeams where [TournamentTeams].[Team] point to this entity (FK_TournamentTeams_Teams)
        /// </summary>
        public virtual ICollection<TournamentTeam> TournamentTeams { get; set; }

        // Foreign keys
        [ForeignKey("TypeTitle")]
        public virtual Type Type { get; set; }
        [ForeignKey("FederationName")]
        public virtual Federation Federation { get; set; }
    }
}

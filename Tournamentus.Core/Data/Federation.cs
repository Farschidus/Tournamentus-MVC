using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public class Federation
    {
        public const int FederationMaxLength = 50;

        [Key, Column("Federation"), Required, MaxLength(FederationMaxLength)]
        public string FederationName { get; set; }

        // Reverse navigation
        /// <summary>
        /// Child Teams where [Teams].[Federation] point to this entity (FK_Teams_Federations)
        /// </summary>
        public virtual ICollection<Team> Teams { get; set; }
        /// <summary>
        /// Child Tournaments where [Tournaments].[Federation] point to this entity (FK_Tournaments_Federations)
        /// </summary>
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}

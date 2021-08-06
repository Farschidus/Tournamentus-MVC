using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public class Type
    {
        public const int TypeMaxLength = 50;

        [Key, Column("Type"), Required, MaxLength(TypeMaxLength)]
        public string TypeName { get; set; }

        // Reverse navigation
        /// <summary>
        /// Child Teams where [Teams].[Type] point to this entity (FK_Teams_Types)
        /// </summary>
        public virtual ICollection<Team> Teams { get; set; }
        /// <summary>
        /// Child Tournaments where [Tournaments].[Type] point to this entity (FK_Tournaments_Types)
        /// </summary>
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}

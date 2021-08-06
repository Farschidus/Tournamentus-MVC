using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public class Stage
    {
        public const int StageMaxLength = 50;

        [Key, Column("Stage"), Required, MaxLength(StageMaxLength)]
        public string StageTitle { get; set; }
    }
}

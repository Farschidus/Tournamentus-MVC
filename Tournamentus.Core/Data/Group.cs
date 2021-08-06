using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tournamentus.Core.Data
{
    public class Group
    {
        public const int GrouMaxLength = 50;

        [Key, Column("Group"), Required, MaxLength(GrouMaxLength)]
        public string GroupTitle { get; set; }
    }
}

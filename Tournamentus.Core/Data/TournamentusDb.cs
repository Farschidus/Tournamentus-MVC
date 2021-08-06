using Tournamentus.Core.Data.Identity;
using Tournamentus.Core.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tournamentus.Core.Data
{
    public class TournamentusDb : IdentityDbContext<User, Role, int>
    {
        private readonly string _connectionString;

        public TournamentusDb(ConnectionStringSettings connectionStringSettings)
            : base()
        {
            _connectionString = connectionStringSettings.TournamentusDb;
        }

        public TournamentusDb(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        public TournamentusDb(DbContextOptions<TournamentusDb> options)
            : base(options)
        {
        }


        public virtual DbSet<Federation> Federations { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<PredictScore> PredictScores { get; set; }
        public virtual DbSet<Stage> Stages { get; set; } 
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Timezone> Timezones { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<TournamentParticipator> TournamentParticipators { get; set; }
        public virtual DbSet<TournamentTeam> TournamentTeams { get; set; } 
        public virtual DbSet<TournamentTeamGroup> TournamentTeamGroups { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<UserPredict> UserPredicts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("AspNetUsers", "dbo");
            builder.Entity<Role>().ToTable("AspNetRoles", "dbo");
            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "dbo");
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "dbo");
            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "dbo");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "dbo");
            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "dbo");
        }
    }
}

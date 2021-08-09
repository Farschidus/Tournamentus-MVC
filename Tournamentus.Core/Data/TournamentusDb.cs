using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Tournamentus.Core.Data.Identity;
using Tournamentus.Core.Infrastructure;

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
        public virtual DbSet<Participator> Participators { get; set; }
        public virtual DbSet<TournamentTeam> TournamentTeams { get; set; } 
        public virtual DbSet<TournamentTeamGroup> TournamentTeamGroups { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<ParticipatorPredict> ParticipatorPredicts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("AspNetUsers", "dbo");
            builder.Entity<Role>().ToTable("AspNetRoles", "dbo");
            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "dbo").HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "dbo").HasKey(x => new { x.LoginProvider, x.ProviderKey });
            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "dbo").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "dbo").HasKey(x => x.Id);
            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "dbo").HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

            builder.Entity<ParticipatorPredict>().ToTable("ParticipatorPredict", "dbo").HasKey(x => new { x.ParticipatorUserId, x.ParticipatorTournamentId, x.GameId });
            // builder.Entity<Participators>().ToTable("ParticipatorPredict", "dbo").HasKey(x => new { x.ParticipatorUserId, x.ParticipatorTournamentId, x.GameId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, option => option.EnableRetryOnFailure(10, TimeSpan.FromSeconds(1), null));
            }
        }
    }
}

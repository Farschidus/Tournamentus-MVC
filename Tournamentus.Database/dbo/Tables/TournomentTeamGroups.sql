create table dbo.TournamentTeamGroups
(
	TournamentTeamId int not null,
    [Group] nvarchar(50) not null,
    Play tinyint not null default 0,
    Wins tinyint not null default 0,
    Drwas tinyint not null default 0,
    Losses tinyint not null default 0,
    GoalsFor tinyint not null default 0,
    GoalsAgainst tinyint not null default 0,
    GoalDiff tinyint not null default 0,
    Points tinyint not null default 0
)
go

-- primary key
alter table dbo.TournamentTeamGroups
    add constraint PK_TournamentTeamGroups primary key clustered (TournamentTeamId, [Group])
go

-- foreign key
alter table dbo.TournamentTeamGroups
    add constraint FK_TournamentTeamGroups_TournamentTeams foreign key (TournamentTeamId) references dbo.TournamentTeams (TournamentTeamId)
        on delete no action
go

alter table dbo.TournamentTeamGroups
    add constraint FK_TournamentTeamGroups_Groups foreign key ([Group]) references dbo.Groups ([Group])
        on delete no action
go

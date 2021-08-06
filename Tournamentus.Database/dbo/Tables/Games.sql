create table dbo.Games
(
	GameId int not null,
	TournamentTeamIdA int not null,
	TournamentTeamIdB int not null,
    Stage nvarchar(50) not null,
	Winner int null,
	IsEqual bit null default 0,
	Result nvarchar(50) null,
	InPenalty bit null default 0,
	PenaltyScore nvarchar(50) null,
	GameDateTime datetimeoffset(0) null,
    TimezoneId nvarchar(50) null
)
go

-- primary key
alter table dbo.Games
    add constraint PK_Games primary key clustered (GameId)
go

-- foreign key
alter table dbo.Games
    add constraint FK_Games_TournamentTeams_A foreign key (TournamentTeamIdA) references dbo.TournamentTeams (TournamentTeamId)
        on delete no action
go

alter table dbo.Games
    add constraint FK_Games_TournamentTeams_B foreign key (TournamentTeamIdB) references dbo.TournamentTeams (TournamentTeamId)
        on delete no action
go

alter table dbo.Games
    add constraint FK_Games_TournamentTeams_Winner foreign key (Winner) references dbo.TournamentTeams (TournamentTeamId)
        on delete no action
go

alter table dbo.Games
    add constraint FK_Games_TournamentTeams_Stages foreign key (Stage) references dbo.Stages (Stage)
        on delete no action
go

alter table dbo.Games
    add constraint FK_Games_Timezones foreign key (TimezoneId) references dbo.Timezones (TimezoneId)
        on delete no action
go


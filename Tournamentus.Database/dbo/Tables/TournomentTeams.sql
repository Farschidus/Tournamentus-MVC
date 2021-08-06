create table dbo.TournamentTeams
(
	TournamentTeamId int identity(1,1) not null,
    TournamentId int not null,
    Team nvarchar(50) not null
)
go

-- primary key
alter table dbo.TournamentTeams
    add constraint PK_TournamentTeams primary key clustered (TournamentTeamId)
go

-- foreign key
alter table dbo.TournamentTeams
    add constraint FK_TournamentTeams_Tournoments foreign key (TournamentId) references dbo.Tournaments (TournamentId)
        on delete no action
go

alter table dbo.TournamentTeams
    add constraint FK_TournamentTeams_Teams foreign key (Team) references dbo.Teams (Team)
        on delete no action
go

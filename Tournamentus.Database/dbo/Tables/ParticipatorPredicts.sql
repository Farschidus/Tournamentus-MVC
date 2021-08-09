create table dbo.ParticipatorPredicts
(
    ParticipatorUserId int not null,
    ParticipatorTournamentId int not null,
	GameId int not null,
	Predict nvarchar(50) not null,
    PredictScore tinyint null,
)
go

-- primary key
alter table dbo.ParticipatorPredicts
    add constraint PK_ParticipatorPredicts primary key clustered (ParticipatorUserId, ParticipatorTournamentId, GameId)
go

-- foreign key
alter table dbo.ParticipatorPredicts
    add constraint FK_ParticipatorPredicts_Participators foreign key (ParticipatorUserId, ParticipatorTournamentId) references dbo.Participators (ParticipatorUserId, ParticipatorTournamentId)
        on delete cascade
go

alter table dbo.ParticipatorPredicts
    add constraint FK_ParticipatorPredicts_Games foreign key (GameId) references dbo.Games (GameId)
        on delete cascade
go

alter table dbo.ParticipatorPredicts
    add constraint FK_ParticipatorPredicts_PredictScores foreign key (PredictScore) references dbo.PredictScores (PredictScore)
        on delete cascade
go

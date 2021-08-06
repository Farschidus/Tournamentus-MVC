create table dbo.UserPredicts
(
    UserId int not null,
    TournamentId int not null,
	GameId int not null,
	Predict nvarchar(50) not null,
    PredictScore tinyint null,
)
go

-- primary key
alter table dbo.UserPredicts
    add constraint PK_UserPredicts primary key clustered (UserId, TournamentId, GameId)
go

-- foreign key
alter table dbo.UserPredicts
    add constraint FK_UserPredicts_TournamentParticipators foreign key (UserId, TournamentId) references dbo.TournamentParticipators (UserId, TournamentId)
        on delete cascade
go

alter table dbo.UserPredicts
    add constraint FK_UserPredicts_Games foreign key (GameId) references dbo.Games (GameId)
        on delete cascade
go

alter table dbo.UserPredicts
    add constraint FK_UserPredicts_PredictScores foreign key (PredictScore) references dbo.PredictScores (PredictScore)
        on delete cascade
go

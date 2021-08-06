create table dbo.TournamentParticipators
(
    UserId int not null,
    TournamentId int not null,
    TimezoneId nvarchar(50) not null
)
go

-- primary key
alter table dbo.TournamentParticipators
    add constraint PK_TournamentParticipators primary key clustered (UserId, TournamentId)
go

-- foreign key
alter table dbo.TournamentParticipators
    add constraint FK_TournamentParticipators_Users foreign key (UserId) references dbo.AspNetUsers (Id)
        on delete no action
go

alter table dbo.TournamentParticipators
    add constraint FK_TournamentParticipators_Tournaments foreign key (TournamentId) references dbo.Tournaments (TournamentId)
        on delete no action
go

alter table dbo.TournamentParticipators
    add constraint FK_TournamentParticipators_Timezones foreign key (TimezoneId) references dbo.Timezones (TimezoneId)
        on delete no action
go

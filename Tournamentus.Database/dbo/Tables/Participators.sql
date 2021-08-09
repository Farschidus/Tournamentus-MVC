create table dbo.Participators
(
    ParticipatorUserId int not null,
    ParticipatorTournamentId int not null,
    ParticipatorTimezone nvarchar(50) not null
)
go

-- primary key
alter table dbo.Participators
    add constraint PK_Participators primary key clustered (ParticipatorUserId, ParticipatorTournamentId)
go

-- foreign key
alter table dbo.Participators
    add constraint FK_Participators_Users foreign key (ParticipatorUserId) references dbo.AspNetUsers (Id)
        on delete no action
go

alter table dbo.Participators
    add constraint FK_Participators_Tournaments foreign key (ParticipatorTournamentId) references dbo.Tournaments (TournamentId)
        on delete no action
go

alter table dbo.Participators
    add constraint FK_Participators_Timezones foreign key (ParticipatorTimezone) references dbo.Timezones (TimezoneId)
        on delete no action
go

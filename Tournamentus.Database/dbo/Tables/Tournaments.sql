create table dbo.Tournaments
(
    TournamentId int identity(1,1) not null,
	Title nvarchar(128) not null,
    [Type] nvarchar(50) not null,
    Federation nvarchar(50) not null,
    IsActive bit not null default 0
)
go

-- primary key
alter table dbo.Tournaments
    add constraint PK_Tournaments primary key clustered (TournamentId)
go

-- foreign key
alter table dbo.Tournaments
    add constraint FK_Tournaments_Types foreign key ([Type]) references dbo.[Types] ([Type])
        on delete no action
go

alter table dbo.Tournaments
    add constraint FK_Tournaments_Federations foreign key (Federation) references dbo.Federations (Federation)
        on delete no action
go

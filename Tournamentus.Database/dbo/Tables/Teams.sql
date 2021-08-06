create table dbo.Teams
(
	Team nvarchar(50) not null,
    Abbr nvarchar(20) not null,
    [Type] nvarchar(50) not null,
    Federation nvarchar(50) not null
)
go

-- primary key
alter table dbo.Teams
    add constraint PK_Teams primary key clustered (Team)
go

-- foreign key
alter table dbo.Teams
    add constraint FK_Teams_Types foreign key ([Type]) references dbo.[Types] ([Type])
        on delete no action
go

alter table dbo.Teams
    add constraint FK_Teams_Federations foreign key (Federation) references dbo.Federations (Federation)
        on delete no action
go

create table dbo.Federations
(
	Federation nvarchar(50) not null
)
go

-- primary key
alter table dbo.Federations
    add constraint PK_Federations primary key clustered (Federation)
go

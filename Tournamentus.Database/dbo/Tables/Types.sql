create table dbo.[Types]
(
	[Type] nvarchar(50) not null
)
go

-- primary key
alter table dbo.[Types]
    add constraint PK_Types primary key clustered ([Type])
go

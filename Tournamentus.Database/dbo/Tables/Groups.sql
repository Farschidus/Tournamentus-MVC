create table dbo.Groups
(
    [Group] nvarchar(50) not null,
)
go

-- primary key
alter table dbo.Groups
    add constraint PK_Groups primary key clustered ([Group])
go

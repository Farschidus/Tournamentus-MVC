create table dbo.Stages
(
    Stage nvarchar(50) not null,
)
go

-- primary key
alter table dbo.Stages
    add constraint PK_Stages primary key clustered (Stage)
go

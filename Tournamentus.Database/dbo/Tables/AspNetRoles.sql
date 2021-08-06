create table dbo.AspNetRoles
(
    Id int identity(1,1) not null,
    [Name] nvarchar(256) null,
    NormalizedName nvarchar(256) null,
    ConcurrencyStamp nvarchar(max) null    
)
go

-- primary key
alter table dbo.AspNetRoles
    add constraint PK_AspNetRoles primary key clustered (Id)
go
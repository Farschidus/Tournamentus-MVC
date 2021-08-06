create table dbo.AspNetRoleClaims
(
    Id int identity(1,1) not null,
    RoleId int not null,
    ClaimType nvarchar(max) null,
    ClaimValue nvarchar(max) null
)
go

-- primary key
alter table dbo.AspNetRoleClaims
    add constraint PK_AspNetRoleClaims primary key clustered (Id)
go

-- foreign key
alter table dbo.AspNetRoleClaims
    add constraint FK_AspNetRoleClaims_AspNetRoles_RoleId foreign key (RoleId) references dbo.AspNetRoles (Id)
        on delete cascade
go

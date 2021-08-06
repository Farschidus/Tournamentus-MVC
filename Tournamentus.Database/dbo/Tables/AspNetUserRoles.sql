create table dbo.AspNetUserRoles
(
    UserId int not null,
    RoleId int not null
)
go

-- primary key
alter table dbo.AspNetUserRoles
    add constraint PK_AspNetUserRoles primary key clustered (UserId, RoleId)
go

-- foreign keys
alter table dbo.AspNetUserRoles
    add constraint FK_AspNetUserRoles_AspNetUsers_UserId foreign key (UserId) references dbo.AspNetUsers (Id)
        on delete cascade
go

alter table dbo.AspNetUserRoles
    add constraint FK_AspNetUserRoles_AspNetRoles_RoleId foreign key (RoleId) references dbo.AspNetRoles (Id)
        on delete cascade
go

create table dbo.AspNetUserClaims
(
    Id int identity(1,1) not null,
    UserId int not null,
    ClaimType nvarchar(max) null,
    ClaimValue nvarchar(max) null
)
go

-- primary key
alter table dbo.AspNetUserClaims
    add constraint PK_AspNetUserClaims primary key clustered (Id)
go

-- foreign key
alter table dbo.AspNetUserClaims
    add constraint FK_AspNetUserClaims_AspNetUsers_UserId foreign key (UserId) references dbo.AspNetUsers (Id)
        on delete cascade
go

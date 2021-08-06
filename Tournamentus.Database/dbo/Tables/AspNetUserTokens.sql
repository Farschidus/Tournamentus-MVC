create table dbo.AspNetUserTokens
(
    UserId int not null,
    LoginProvider nvarchar(128) not null,
    [Name] nvarchar(128) not null,
    [Value] nvarchar(max) null
)
go

-- primary key
alter table dbo.AspNetUserTokens
    add constraint PK_AspNetUserTokens primary key clustered (UserId, LoginProvider, [Name])
go

-- foreign key
alter table dbo.AspNetUserTokens
    add constraint FK_AspNetUserTokens_AspNetUsers_UserId foreign key (UserId) references dbo.AspNetUsers (Id)
        on delete cascade
go
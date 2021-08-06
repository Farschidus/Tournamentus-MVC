create table dbo.AspNetUserLogins
(
    LoginProvider nvarchar(128) not null,
    ProviderKey nvarchar(128) not null,
    ProviderDisplayName nvarchar(max) null,
    UserId int not null
)
go

-- primary key
alter table dbo.AspNetUserLogins
    add constraint PK_AspNetUserLogins primary key clustered (LoginProvider, ProviderKey)
go

-- foreign key
alter table dbo.AspNetUserLogins
    add constraint FK_AspNetUserLogins_AspNetUsers_UserId foreign key (UserId) references dbo.AspNetUsers (Id)
        on delete cascade
go

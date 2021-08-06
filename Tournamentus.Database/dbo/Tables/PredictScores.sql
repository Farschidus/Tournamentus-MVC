create table dbo.PredictScores
(
    PredictScore tinyint not null,
    Title nvarchar(50) not null,
	[Description] nvarchar(100) not null
)
go

-- primary key
alter table dbo.PredictScores
    add constraint PK_PredictScores primary key clustered (PredictScore)
go

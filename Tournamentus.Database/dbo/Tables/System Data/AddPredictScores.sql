print 'inserting into dbo.PredictScores'

insert into dbo.PredictScores
    (PredictScore, title, [Description])
values
    (0, 'Wrong', 'Wrong'),
    (2, 'Result', 'old result'),
    (3, 'Difference', 'old difference'),
    (5, 'Result', 'Result or old Correct'),
    (7, 'Difference', 'Difference'),
    (10, 'Correct', 'Correct')

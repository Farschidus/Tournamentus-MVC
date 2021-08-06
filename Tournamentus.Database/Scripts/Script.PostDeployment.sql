/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* Add System Data */
:r "..\dbo\Tables\System Data\AddTimezones.sql"
:r "..\dbo\Tables\System Data\AddTypes.sql"
:r "..\dbo\Tables\System Data\AddFederations.sql"
:r "..\dbo\Tables\System Data\AddGroups.sql"
:r "..\dbo\Tables\System Data\AddStages.sql"
:r "..\dbo\Tables\System Data\AddTournaments.sql"
:r "..\dbo\Tables\System Data\AddPredictScores.sql"
--:r "..\dbo\Tables\System Data\AddTeams.sql"

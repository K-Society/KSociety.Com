CREATE VIEW [std].[TagGroupReadyView] AS 
SELECT
[Id],
[Name], 
[Clock], 
[Update]
FROM [std].[TagGroup]
WHERE [std].[TagGroup].[Enable] = 1
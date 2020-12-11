CREATE VIEW [kb].[TagGroupReadyView] AS 
SELECT
[Id],
[Name], 
[Clock], 
[Update]
FROM [kb].[TagGroup]
WHERE [kb].[TagGroup].[Enable] = 1
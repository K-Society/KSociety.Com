CREATE VIEW [ksociety].[TagGroupReadyView] AS 
SELECT
[Id],
[Name], 
[Clock], 
[Update]
FROM [ksociety].[TagGroup]
WHERE [ksociety].[TagGroup].[Enable] = 1
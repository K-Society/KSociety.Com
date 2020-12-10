CREATE VIEW [kb].[ConnectionReadyView] AS 
SELECT
[Id],
[AutomationTypeId],
[Name],
[Ip],
[WriteEnable],
[Path],
[CpuTypeId],
[Rack],
[Slot],
[ConnectionTypeId]
FROM [kb].[Connection]
WHERE [kb].[Connection].[Enable] = 1
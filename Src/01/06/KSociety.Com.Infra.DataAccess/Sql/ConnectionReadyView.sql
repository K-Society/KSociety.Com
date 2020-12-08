CREATE VIEW [std].[ConnectionReadyView] AS 
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
FROM [std].[Connection]
WHERE [std].[Connection].[Enable] = 1
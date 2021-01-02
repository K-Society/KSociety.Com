CREATE VIEW [ksociety].[ConnectionReadyView] AS 
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
FROM [ksociety].[Connection]
WHERE [ksociety].[Connection].[Enable] = 1
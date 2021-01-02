CREATE VIEW [ksociety].[ConnectionAutomationView] AS 
SELECT
[ksociety].[ConnectionReadyView].[Id],
[ksociety].[ConnectionReadyView].[AutomationTypeId],
[ksociety].[AutomationType].[Name] AS AutomationName,
[ksociety].[ConnectionReadyView].[Name] AS ConnectionName,
[Ip],
[WriteEnable],
[Path],
[CpuTypeId],
[Rack],
[Slot],
[ConnectionTypeId]
FROM [ksociety].[ConnectionReadyView]
INNER JOIN [ksociety].[AutomationType] ON [ksociety].[ConnectionReadyView].[AutomationTypeId] = [ksociety].[AutomationType].[Id]

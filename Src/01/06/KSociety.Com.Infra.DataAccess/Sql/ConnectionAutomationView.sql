CREATE VIEW [kb].[ConnectionAutomationView] AS 
SELECT
[kb].[ConnectionReadyView].[Id],
[kb].[ConnectionReadyView].[AutomationTypeId],
[kb].[AutomationType].[Name] AS AutomationName,
[kb].[ConnectionReadyView].[Name] AS ConnectionName,
[Ip],
[WriteEnable],
[Path],
[CpuTypeId],
[Rack],
[Slot],
[ConnectionTypeId]
FROM [kb].[ConnectionReadyView]
INNER JOIN [kb].[AutomationType] ON [kb].[ConnectionReadyView].[AutomationTypeId] = [kb].[AutomationType].[Id]

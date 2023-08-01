CREATE VIEW [ConnectionAutomationView] AS 
SELECT
[ConnectionReadyView].[Id],
[ConnectionReadyView].[AutomationTypeId],
[AutomationType].[Name] AS [AutomationName],
[ConnectionReadyView].[Name] AS [ConnectionName],
[Ip],
[WriteEnable],
[Path],
[CpuTypeId],
[Rack],
[Slot],
[ConnectionTypeId]
FROM [ConnectionReadyView]
INNER JOIN [AutomationType] ON [ConnectionReadyView].[AutomationTypeId] = [AutomationType].[Id]

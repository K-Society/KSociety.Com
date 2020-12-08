CREATE VIEW [std].[ConnectionAutomationView] AS 
SELECT
[std].[ConnectionReadyView].[Id],
[std].[ConnectionReadyView].[AutomationTypeId],
[std].[AutomationType].[Name] AS AutomationName,
[std].[ConnectionReadyView].[Name] AS ConnectionName,
[Ip],
[WriteEnable],
[Path],
[CpuTypeId],
[Rack],
[Slot],
[ConnectionTypeId]
FROM [std].[ConnectionReadyView]
INNER JOIN [std].[AutomationType] ON [std].[ConnectionReadyView].[AutomationTypeId] = [std].[AutomationType].[Id]

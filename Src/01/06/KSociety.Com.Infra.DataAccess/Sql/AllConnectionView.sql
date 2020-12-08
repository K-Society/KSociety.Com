CREATE VIEW [std].[AllConnectionView] AS 
SELECT
[std].[ConnectionAutomationView].[Id],
[std].[ConnectionAutomationView].[AutomationTypeId],
[AutomationName],
[ConnectionName],
[Ip],
[WriteEnable],
[Path],
[std].[ConnectionAutomationView].[CpuTypeId],
[std].[S7CpuType].[CpuTypeName],
[Rack],
[Slot],
[std].[ConnectionAutomationView].[ConnectionTypeId],
[std].[S7ConnectionType].[Name] AS [ConnectionTypeName]
FROM [std].[ConnectionAutomationView]
INNER JOIN [std].[S7CpuType] ON [std].[ConnectionAutomationView].[CpuTypeId] = [std].[S7CpuType].[Id]
INNER JOIN [std].[S7ConnectionType] ON [std].[ConnectionAutomationView].[ConnectionTypeId] = [std].[S7ConnectionType].[Id]
WHERE [std].[ConnectionAutomationView].[AutomationTypeId] >= 1

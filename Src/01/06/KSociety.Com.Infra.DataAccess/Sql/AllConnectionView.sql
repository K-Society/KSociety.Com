CREATE VIEW [kb].[AllConnectionView] AS 
SELECT
[kb].[ConnectionAutomationView].[Id],
[kb].[ConnectionAutomationView].[AutomationTypeId],
[AutomationName],
[ConnectionName],
[Ip],
[WriteEnable],
[Path],
[kb].[ConnectionAutomationView].[CpuTypeId],
[kb].[S7CpuType].[CpuTypeName],
[Rack],
[Slot],
[kb].[ConnectionAutomationView].[ConnectionTypeId],
[kb].[S7ConnectionType].[Name] AS [ConnectionTypeName]
FROM [kb].[ConnectionAutomationView]
INNER JOIN [kb].[S7CpuType] ON [kb].[ConnectionAutomationView].[CpuTypeId] = [kb].[S7CpuType].[Id]
INNER JOIN [kb].[S7ConnectionType] ON [kb].[ConnectionAutomationView].[ConnectionTypeId] = [kb].[S7ConnectionType].[Id]
WHERE [kb].[ConnectionAutomationView].[AutomationTypeId] >= 1

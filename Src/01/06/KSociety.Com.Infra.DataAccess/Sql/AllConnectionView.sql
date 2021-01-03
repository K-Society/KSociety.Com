CREATE VIEW [ksociety].[AllConnectionView] AS 
SELECT
[ksociety].[ConnectionAutomationView].[Id],
[ksociety].[ConnectionAutomationView].[AutomationTypeId],
[AutomationName],
[ConnectionName],
[Ip],
[WriteEnable],
[Path],
[ksociety].[ConnectionAutomationView].[CpuTypeId],
[ksociety].[S7CpuType].[CpuTypeName],
[Rack],
[Slot],
[ksociety].[ConnectionAutomationView].[ConnectionTypeId],
[ksociety].[S7ConnectionType].[Name] AS [ConnectionTypeName]
FROM [ksociety].[ConnectionAutomationView]
INNER JOIN [ksociety].[S7CpuType] ON [ksociety].[ConnectionAutomationView].[CpuTypeId] = [ksociety].[S7CpuType].[Id]
INNER JOIN [ksociety].[S7ConnectionType] ON [ksociety].[ConnectionAutomationView].[ConnectionTypeId] = [ksociety].[S7ConnectionType].[Id]
WHERE [ksociety].[ConnectionAutomationView].[AutomationTypeId] >= 1

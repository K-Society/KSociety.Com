CREATE VIEW [kb].[TagConnectionView] AS 
SELECT
[kb].[TagReadyView].[Id],
[kb].[TagReadyView].[Name] AS [TagName],
[kb].[TagReadyView].[ConnectionId],
[kb].[ConnectionAutomationView].[ConnectionName],
[kb].[ConnectionAutomationView].[AutomationTypeId],
[kb].[ConnectionAutomationView].[AutomationName],
[kb].[ConnectionAutomationView].[Ip],
[kb].[ConnectionAutomationView].[WriteEnable],
[kb].[ConnectionAutomationView].[Path],
[kb].[ConnectionAutomationView].[CpuTypeId],
[kb].[ConnectionAutomationView].[Rack],
[kb].[ConnectionAutomationView].[Slot],
[kb].[ConnectionAutomationView].[ConnectionTypeId],
[InputOutput], 
[AnalogDigitalSignal],
[MemoryAddress],
[Invoke],
[TagGroupId],
[DataBlock],
[Offset],
[BitOfByte],
[WordLenId],
[AreaId],
[StringLength]
FROM [kb].[TagReadyView]
INNER JOIN [kb].[ConnectionAutomationView] ON [kb].[TagReadyView].[ConnectionId] = [kb].[ConnectionAutomationView].[Id]

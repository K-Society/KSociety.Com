CREATE VIEW [ksociety].[TagConnectionView] AS 
SELECT
[ksociety].[TagReadyView].[Id],
[ksociety].[TagReadyView].[Name] AS [TagName],
[ksociety].[TagReadyView].[ConnectionId],
[ksociety].[ConnectionAutomationView].[ConnectionName],
[ksociety].[ConnectionAutomationView].[AutomationTypeId],
[ksociety].[ConnectionAutomationView].[AutomationName],
[ksociety].[ConnectionAutomationView].[Ip],
[ksociety].[ConnectionAutomationView].[WriteEnable],
[ksociety].[ConnectionAutomationView].[Path],
[ksociety].[ConnectionAutomationView].[CpuTypeId],
[ksociety].[ConnectionAutomationView].[Rack],
[ksociety].[ConnectionAutomationView].[Slot],
[ksociety].[ConnectionAutomationView].[ConnectionTypeId],
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
FROM [ksociety].[TagReadyView]
INNER JOIN [ksociety].[ConnectionAutomationView] ON [ksociety].[TagReadyView].[ConnectionId] = [ksociety].[ConnectionAutomationView].[Id]

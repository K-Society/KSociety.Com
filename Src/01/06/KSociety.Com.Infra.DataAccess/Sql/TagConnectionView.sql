CREATE VIEW [std].[TagConnectionView] AS 
SELECT
[std].[TagReadyView].[Id],
[std].[TagReadyView].[Name] AS [TagName],
[std].[TagReadyView].[ConnectionId],
[std].[ConnectionAutomationView].[ConnectionName],
[std].[ConnectionAutomationView].[AutomationTypeId],
[std].[ConnectionAutomationView].[AutomationName],
[std].[ConnectionAutomationView].[Ip],
[std].[ConnectionAutomationView].[WriteEnable],
[std].[ConnectionAutomationView].[Path],
[std].[ConnectionAutomationView].[CpuTypeId],
[std].[ConnectionAutomationView].[Rack],
[std].[ConnectionAutomationView].[Slot],
[std].[ConnectionAutomationView].[ConnectionTypeId],
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
FROM [std].[TagReadyView]
INNER JOIN [std].[ConnectionAutomationView] ON [std].[TagReadyView].[ConnectionId] = [std].[ConnectionAutomationView].[Id]

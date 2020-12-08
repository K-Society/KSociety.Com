CREATE VIEW [std].[TagGroupConnectionView] AS 
SELECT
[std].[TagConnectionView].[Id],
[TagName],
[ConnectionId],
[ConnectionName],
[AutomationTypeId],
[AutomationName],
[Ip],
[WriteEnable],
[Path],
[CpuTypeId],
[Rack],
[Slot],
[ConnectionTypeId],
[InputOutput], 
[AnalogDigitalSignal],
[Invoke],
[std].[TagGroupReadyView].[Id] AS [TagGroupId],
[std].[TagGroupReadyView].[Name] AS [TagGroupName],
[std].[TagGroupReadyView].[Clock] AS [Clock],
[std].[TagGroupReadyView].[Update] AS [Update]
FROM [std].[TagConnectionView]
INNER JOIN [std].[TagGroupReadyView] ON [std].[TagConnectionView].[TagGroupId] = [std].[TagGroupReadyView].[Id]

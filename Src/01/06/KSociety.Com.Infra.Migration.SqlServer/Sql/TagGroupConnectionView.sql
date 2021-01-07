CREATE VIEW [TagGroupConnectionView] AS 
SELECT
[TagConnectionView].[Id],
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
[TagGroupReadyView].[Id] AS [TagGroupId],
[TagGroupReadyView].[Name] AS [TagGroupName],
[TagGroupReadyView].[Clock] AS [Clock],
[TagGroupReadyView].[Update] AS [Update]
FROM [TagConnectionView]
INNER JOIN [TagGroupReadyView] ON [TagConnectionView].[TagGroupId] = [TagGroupReadyView].[Id]

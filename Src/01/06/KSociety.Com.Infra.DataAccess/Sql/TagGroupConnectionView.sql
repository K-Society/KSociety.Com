CREATE VIEW [ksociety].[TagGroupConnectionView] AS 
SELECT
[ksociety].[TagConnectionView].[Id],
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
[ksociety].[TagGroupReadyView].[Id] AS [TagGroupId],
[ksociety].[TagGroupReadyView].[Name] AS [TagGroupName],
[ksociety].[TagGroupReadyView].[Clock] AS [Clock],
[ksociety].[TagGroupReadyView].[Update] AS [Update]
FROM [ksociety].[TagConnectionView]
INNER JOIN [ksociety].[TagGroupReadyView] ON [ksociety].[TagConnectionView].[TagGroupId] = [ksociety].[TagGroupReadyView].[Id]

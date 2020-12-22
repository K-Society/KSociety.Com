CREATE VIEW [kb].[TagGroupConnectionView] AS 
SELECT
[kb].[TagConnectionView].[Id],
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
[kb].[TagGroupReadyView].[Id] AS [TagGroupId],
[kb].[TagGroupReadyView].[Name] AS [TagGroupName],
[kb].[TagGroupReadyView].[Clock] AS [Clock],
[kb].[TagGroupReadyView].[Update] AS [Update]
FROM [kb].[TagConnectionView]
INNER JOIN [kb].[TagGroupReadyView] ON [kb].[TagConnectionView].[TagGroupId] = [kb].[TagGroupReadyView].[Id]

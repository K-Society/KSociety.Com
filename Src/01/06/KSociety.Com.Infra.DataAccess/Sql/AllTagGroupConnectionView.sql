CREATE VIEW [ksociety].[AllTagGroupConnectionView] AS 
SELECT
[ksociety].[TagConnectionView].[Id],
[TagName],
[ConnectionId],
[ConnectionName],
[AutomationTypeId],
[AutomationName],
[Ip],
[WriteEnable],
[CpuTypeId],
[Rack],
[Slot],
[ConnectionTypeId],
[InputOutput], 
[AnalogDigitalSignal],
[MemoryAddress],
[Invoke],
[DataBlock],
[Offset],
[BitOfByte],
[ksociety].[TagConnectionView].[WordLenId],
[ksociety].[TagConnectionView].[AreaId],
[ksociety].[TagConnectionView].[StringLength],
[Path],
[ksociety].[TagGroupReadyView].[Id] AS [TagGroupId],
[ksociety].[TagGroupReadyView].[Name] AS [TagGroupName],
[ksociety].[TagGroupReadyView].[Clock] AS [Clock],
[ksociety].[TagGroupReadyView].[Update] AS [Update],
[ksociety].[S7WordLen].[WordLenName] AS [WordLenName],
[ksociety].[S7Area].[AreaName] AS [AreaName]
FROM [ksociety].[TagConnectionView]
INNER JOIN [ksociety].[TagGroupReadyView] ON [ksociety].[TagConnectionView].[TagGroupId] = [ksociety].[TagGroupReadyView].[Id]
INNER JOIN [ksociety].[S7WordLen] ON [ksociety].[S7WordLen].[Id] = [ksociety].[TagConnectionView].[WordLenId]
INNER JOIN [ksociety].[S7Area] ON [ksociety].[S7Area].[Id] = [ksociety].[TagConnectionView].[AreaId]
WHERE [ksociety].[TagConnectionView].[AutomationTypeId] >= 1
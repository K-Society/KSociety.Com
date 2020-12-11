CREATE VIEW [kb].[AllTagGroupConnectionView] AS 
SELECT
[kb].[TagConnectionView].[Id],
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
[kb].[TagConnectionView].[WordLenId],
[kb].[TagConnectionView].[AreaId],
[kb].[TagConnectionView].[StringLength],
[Path],
[kb].[TagGroupReadyView].[Id] AS [TagGroupId],
[kb].[TagGroupReadyView].[Name] AS [TagGroupName],
[kb].[TagGroupReadyView].[Clock] AS [Clock],
[kb].[TagGroupReadyView].[Update] AS [Update],
[kb].[S7WordLen].[WordLenName] AS [WordLenName],
[kb].[S7Area].[AreaName] AS [AreaName]
FROM [kb].[TagConnectionView]
INNER JOIN [kb].[TagGroupReadyView] ON [kb].[TagConnectionView].[TagGroupId] = [kb].[TagGroupReadyView].[Id]
INNER JOIN [kb].[S7WordLen] ON [kb].[S7WordLen].[Id] = [kb].[TagConnectionView].[WordLenId]
INNER JOIN [kb].[S7Area] ON [kb].[S7Area].[Id] = [kb].[TagConnectionView].[AreaId]
WHERE [kb].[TagConnectionView].[AutomationTypeId] >= 1
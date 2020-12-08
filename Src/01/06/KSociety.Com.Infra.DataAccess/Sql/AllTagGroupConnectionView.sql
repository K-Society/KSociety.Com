CREATE VIEW [std].[AllTagGroupConnectionView] AS 
SELECT
[std].[TagConnectionView].[Id],
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
[std].[TagConnectionView].[WordLenId],
[std].[TagConnectionView].[AreaId],
[std].[TagConnectionView].[StringLength],
[Path],
[std].[TagGroupReadyView].[Id] AS [TagGroupId],
[std].[TagGroupReadyView].[Name] AS [TagGroupName],
[std].[TagGroupReadyView].[Clock] AS [Clock],
[std].[TagGroupReadyView].[Update] AS [Update],
[std].[S7WordLen].[WordLenName] AS [WordLenName],
[std].[S7Area].[AreaName] AS [AreaName]
FROM [std].[TagConnectionView]
INNER JOIN [std].[TagGroupReadyView] ON [std].[TagConnectionView].[TagGroupId] = [std].[TagGroupReadyView].[Id]
INNER JOIN [std].[S7WordLen] ON [std].[S7WordLen].[Id] = [std].[TagConnectionView].[WordLenId]
INNER JOIN [std].[S7Area] ON [std].[S7Area].[Id] = [std].[TagConnectionView].[AreaId]
WHERE [std].[TagConnectionView].[AutomationTypeId] >= 1
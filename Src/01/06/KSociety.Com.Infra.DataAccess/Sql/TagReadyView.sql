CREATE VIEW [kb].[TagReadyView] AS 
SELECT
[Id],
[AutomationTypeId],
[Name],
[ConnectionId],
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
FROM [kb].[Tag]
WHERE [kb].[Tag].[Enable] = 1 AND [InputOutput] <> 'U'
CREATE VIEW [ksociety].[TagReadyView] AS 
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
FROM [ksociety].[Tag]
WHERE [ksociety].[Tag].[Enable] = 1 AND [InputOutput] <> 'U'
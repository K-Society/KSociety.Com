CREATE VIEW [std].[TagReadyView] AS 
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
FROM [std].[Tag]
WHERE [std].[Tag].[Enable] = 1 AND [InputOutput] <> 'U'
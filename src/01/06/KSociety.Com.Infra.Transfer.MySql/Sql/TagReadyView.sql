CREATE VIEW `TagReadyView` AS 
SELECT
`Id`,
`AutomationTypeId`,
`Name`,
`ConnectionId`,
`InputOutput`, 
`AnalogDigitalSignal`,
`MemoryAddress`,
`Invoke`,
`TagGroupId`,
`DataBlock`,
`Offset`,
`BitOfByte`,
`WordLenId`,
`AreaId`,
`StringLength`
FROM `Tag`
WHERE `Tag`.`Enable` = 1 AND `InputOutput` <> 'U'
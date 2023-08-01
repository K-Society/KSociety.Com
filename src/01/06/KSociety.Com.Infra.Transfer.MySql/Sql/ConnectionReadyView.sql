CREATE VIEW `ConnectionReadyView` AS 
SELECT
`Id`,
`AutomationTypeId`,
`Name`,
`Ip`,
`WriteEnable`,
`Path`,
`CpuTypeId`,
`Rack`,
`Slot`,
`ConnectionTypeId`
FROM `Connection`
WHERE `Connection`.`Enable` = 1
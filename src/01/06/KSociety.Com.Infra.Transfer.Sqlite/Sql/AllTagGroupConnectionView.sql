CREATE VIEW "AllTagGroupConnectionView" AS 
SELECT
"TagConnectionView.Id",
"TagName",
"ConnectionId",
"ConnectionName",
"AutomationTypeId",
"AutomationName",
"Ip",
"WriteEnable",
"CpuTypeId",
"Rack",
"Slot",
"ConnectionTypeId",
"InputOutput", 
"AnalogDigitalSignal",
"MemoryAddress",
"Invoke",
"DataBlock",
"Offset",
"BitOfByte",
"TagConnectionView"."WordLenId",
"TagConnectionView"."AreaId",
"TagConnectionView"."StringLength",
"Path",
"TagGroupReadyView"."Id" AS "TagGroupId",
"TagGroupReadyView"."Name" AS "TagGroupName",
"TagGroupReadyView"."Clock" AS "Clock",
"TagGroupReadyView"."Update" AS "Update",
"S7WordLen"."WordLenName" AS "WordLenName",
"S7Area"."AreaName" AS "AreaName"
FROM "TagConnectionView"
INNER JOIN "TagGroupReadyView" ON "TagConnectionView"."TagGroupId" = "TagGroupReadyView"."Id"
INNER JOIN "S7WordLen" ON "S7WordLen"."Id" = "TagConnectionView"."WordLenId"
INNER JOIN "S7Area" ON "S7Area"."Id" = "TagConnectionView"."AreaId"
WHERE "TagConnectionView"."AutomationTypeId" >= 1
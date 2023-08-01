CREATE VIEW "TagConnectionView" AS 
SELECT
"TagReadyView"."Id",
"TagReadyView"."Name" AS "TagName",
"TagReadyView"."ConnectionId",
"ConnectionAutomationView"."ConnectionName",
"ConnectionAutomationView"."AutomationTypeId",
"ConnectionAutomationView"."AutomationName",
"ConnectionAutomationView"."Ip",
"ConnectionAutomationView"."WriteEnable",
"ConnectionAutomationView"."Path",
"ConnectionAutomationView"."CpuTypeId",
"ConnectionAutomationView"."Rack",
"ConnectionAutomationView"."Slot",
"ConnectionAutomationView"."ConnectionTypeId",
"InputOutput", 
"AnalogDigitalSignal",
"MemoryAddress",
"Invoke",
"TagGroupId",
"DataBlock",
"Offset",
"BitOfByte",
"WordLenId",
"AreaId",
"StringLength"
FROM "TagReadyView"
INNER JOIN "ConnectionAutomationView" ON "TagReadyView"."ConnectionId" = "ConnectionAutomationView"."Id"

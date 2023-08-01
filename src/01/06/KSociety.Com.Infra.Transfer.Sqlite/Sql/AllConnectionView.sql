CREATE VIEW "AllConnectionView" AS 
SELECT
"ConnectionAutomationView"."Id",
"ConnectionAutomationView"."AutomationTypeId",
"AutomationName",
"ConnectionName",
"Ip",
"WriteEnable",
"Path",
"ConnectionAutomationView"."CpuTypeId",
"S7CpuType"."CpuTypeName",
"Rack",
"Slot",
"ConnectionAutomationView"."ConnectionTypeId",
"S7ConnectionType"."Name" AS "ConnectionTypeName"
FROM "ConnectionAutomationView"
INNER JOIN "S7CpuType" ON "ConnectionAutomationView"."CpuTypeId" = "S7CpuType"."Id"
INNER JOIN "S7ConnectionType" ON "ConnectionAutomationView"."ConnectionTypeId" = "S7ConnectionType"."Id"
WHERE "ConnectionAutomationView"."AutomationTypeId" >= 1

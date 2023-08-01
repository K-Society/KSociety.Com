CREATE VIEW "TagGroupReadyView" AS 
SELECT
"Id",
"Name", 
"Clock", 
"Update"
FROM "TagGroup"
WHERE "TagGroup"."Enable" = 1
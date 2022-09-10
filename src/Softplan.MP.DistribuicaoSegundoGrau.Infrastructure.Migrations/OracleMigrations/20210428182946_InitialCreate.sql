﻿-- Script was generated by Devart dotConnect for Oracle, Version 9.11.980
-- Product home page: http://www.devart.com/dotconnect/oracle
-- Database version: Oracle 12.2.0.1
-- Script date 28/04/2021 15:39:00

DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM ALL_TABLES WHERE OWNER = 'SAJ_DSG' AND TABLE_NAME = '__MigrationsHistory';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE 'CREATE TABLE SAJ_DSG."__MigrationsHistory" ( 
  "MigrationId" NVARCHAR2(150) NOT NULL,
  "ProductVersion" NVARCHAR2(32) NOT NULL,
  PRIMARY KEY ("MigrationId")
)';
  END IF;
END;

DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210428182946_InitialCreate';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210428182946_InitialCreate'', ''3.1.11'')
';
  END IF;
END;

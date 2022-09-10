CREATE SCHEMA IF NOT EXISTS saj_dsg;
CREATE TABLE IF NOT EXISTS saj_dsg."__MigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___MigrationsHistory" PRIMARY KEY ("MigrationId")
);


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210428204451_InitialCreate') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210428204451_InitialCreate', '3.1.11');
    END IF;
END $$;

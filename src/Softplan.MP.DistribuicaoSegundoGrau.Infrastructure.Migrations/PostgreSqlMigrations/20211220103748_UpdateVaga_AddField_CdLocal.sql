
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211220103748_UpdateVaga_AddField_CdLocal') THEN
    ALTER TABLE saj_dsg.vaga ADD cdlocal integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211220103748_UpdateVaga_AddField_CdLocal') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20211220103748_UpdateVaga_AddField_CdLocal', '3.1.17');
    END IF;
END $$;

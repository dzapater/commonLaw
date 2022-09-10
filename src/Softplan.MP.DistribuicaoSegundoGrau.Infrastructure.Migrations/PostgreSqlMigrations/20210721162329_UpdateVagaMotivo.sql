
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210721162329_UpdateVagaMotivo') THEN
    ALTER TABLE saj_dsg.vaga ALTER COLUMN motivo TYPE text;
    ALTER TABLE saj_dsg.vaga ALTER COLUMN motivo DROP NOT NULL;
    ALTER TABLE saj_dsg.vaga ALTER COLUMN motivo DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210721162329_UpdateVagaMotivo') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210721162329_UpdateVagaMotivo', '3.1.11');
    END IF;
END $$;

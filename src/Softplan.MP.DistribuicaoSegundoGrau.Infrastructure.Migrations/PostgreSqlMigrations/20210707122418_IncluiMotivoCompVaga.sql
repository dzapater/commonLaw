
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210707122418_IncluiMotivoCompVaga') THEN
    ALTER TABLE saj_dsg.vaga ADD motivo integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210707122418_IncluiMotivoCompVaga') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210707122418_IncluiMotivoCompVaga', '3.1.11');
    END IF;
END $$;

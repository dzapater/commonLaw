
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210511120111_UpdateIdProcesso') THEN
    ALTER TABLE saj_dsg.impedimento_processo ALTER COLUMN processo_id TYPE character varying(200);
    ALTER TABLE saj_dsg.impedimento_processo ALTER COLUMN processo_id SET NOT NULL;
    ALTER TABLE saj_dsg.impedimento_processo ALTER COLUMN processo_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210511120111_UpdateIdProcesso') THEN
    ALTER TABLE saj_dsg.analise_processo ALTER COLUMN processo_id TYPE character varying(200);
    ALTER TABLE saj_dsg.analise_processo ALTER COLUMN processo_id SET NOT NULL;
    ALTER TABLE saj_dsg.analise_processo ALTER COLUMN processo_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210511120111_UpdateIdProcesso') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210511120111_UpdateIdProcesso', '3.1.11');
    END IF;
END $$;

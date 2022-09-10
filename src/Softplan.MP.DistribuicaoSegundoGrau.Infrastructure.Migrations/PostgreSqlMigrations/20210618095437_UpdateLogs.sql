
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210618095437_UpdateLogs') THEN
    ALTER TABLE saj_dsg.distribuicao_processo_log DROP CONSTRAINT pk_distribuicao_processo_log;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210618095437_UpdateLogs') THEN
    ALTER TABLE saj_dsg.distribuicao_processo_log ALTER COLUMN processo_id TYPE character varying(200);
    ALTER TABLE saj_dsg.distribuicao_processo_log ALTER COLUMN processo_id DROP NOT NULL;
    ALTER TABLE saj_dsg.distribuicao_processo_log ALTER COLUMN processo_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210618095437_UpdateLogs') THEN
    ALTER TABLE saj_dsg.distribuicao_processo_log ADD CONSTRAINT pk_distribuicao_processo_log PRIMARY KEY (log_id);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210618095437_UpdateLogs') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210618095437_UpdateLogs', '3.1.11');
    END IF;
END $$;

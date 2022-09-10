
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210720125916_UpdateRegraClasse') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_classe DROP COLUMN origem_id;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210720125916_UpdateRegraClasse') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210720125916_UpdateRegraClasse', '3.1.11');
    END IF;
END $$;


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220125162332_UpdateExcecaoVaga_AddField_IdTarja') THEN
    ALTER TABLE saj_dsg.excecao_vaga ADD idtarja bigint NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220125162332_UpdateExcecaoVaga_AddField_IdTarja') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220125162332_UpdateExcecaoVaga_AddField_IdTarja', '3.1.17');
    END IF;
END $$;

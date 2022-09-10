
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220128130949_UpdateExcecaoVaga_RemoveField_IdTarja') THEN
    ALTER TABLE saj_dsg.excecao_vaga DROP COLUMN idtarja;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220128130949_UpdateExcecaoVaga_RemoveField_IdTarja') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220128130949_UpdateExcecaoVaga_RemoveField_IdTarja', '3.1.17');
    END IF;
END $$;


DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220124211834_UpdateExcecaoVaga_AddField_Motivo') THEN
    ALTER TABLE saj_dsg.excecao_vaga ADD motivo character varying(2000) NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220124211834_UpdateExcecaoVaga_AddField_Motivo') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220124211834_UpdateExcecaoVaga_AddField_Motivo', '3.1.17');
    END IF;
END $$;

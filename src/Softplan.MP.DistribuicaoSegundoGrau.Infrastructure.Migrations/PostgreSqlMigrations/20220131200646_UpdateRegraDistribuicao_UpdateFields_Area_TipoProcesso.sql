
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220131200646_UpdateRegraDistribuicao_UpdateFields_Area_TipoProcesso') THEN
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN tipo_processo TYPE integer;
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN tipo_processo DROP NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN tipo_processo DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220131200646_UpdateRegraDistribuicao_UpdateFields_Area_TipoProcesso') THEN
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN area TYPE integer;
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN area DROP NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN area DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220131200646_UpdateRegraDistribuicao_UpdateFields_Area_TipoProcesso') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220131200646_UpdateRegraDistribuicao_UpdateFields_Area_TipoProcesso', '3.1.17');
    END IF;
END $$;

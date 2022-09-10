
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210519210319_IdEspecialidade') THEN
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN especialidade_id TYPE integer;
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN especialidade_id DROP NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN especialidade_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210519210319_IdEspecialidade') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210519210319_IdEspecialidade', '3.1.11');
    END IF;
END $$;

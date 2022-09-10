
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210722144823_DropColumnEspecialidadeRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao DROP COLUMN especialidade_id;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210722144823_DropColumnEspecialidadeRegraDistribuicao') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210722144823_DropColumnEspecialidadeRegraDistribuicao', '3.1.11');
    END IF;
END $$;

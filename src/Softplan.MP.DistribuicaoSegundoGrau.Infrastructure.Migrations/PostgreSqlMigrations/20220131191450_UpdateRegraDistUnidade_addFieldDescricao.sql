
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220131191450_UpdateRegraDistUnidade_addFieldDescricao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_unidade ADD descricao character varying(120) NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220131191450_UpdateRegraDistUnidade_addFieldDescricao') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220131191450_UpdateRegraDistUnidade_addFieldDescricao', '3.1.17');
    END IF;
END $$;

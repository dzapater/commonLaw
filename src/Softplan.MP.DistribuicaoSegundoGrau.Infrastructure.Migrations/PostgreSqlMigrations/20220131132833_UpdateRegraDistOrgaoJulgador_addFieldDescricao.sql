
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220131132833_UpdateRegraDistOrgaoJulgador_addFieldDescricao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_orgao ADD descricao character varying(120) NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220131132833_UpdateRegraDistOrgaoJulgador_addFieldDescricao') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220131132833_UpdateRegraDistOrgaoJulgador_addFieldDescricao', '3.1.17');
    END IF;
END $$;

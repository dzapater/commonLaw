
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220129212858_UpdateRegraDistEspecialidade_addFieldDescricao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_espec ADD descricao character varying(120) NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20220129212858_UpdateRegraDistEspecialidade_addFieldDescricao') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220129212858_UpdateRegraDistEspecialidade_addFieldDescricao', '3.1.17');
    END IF;
END $$;

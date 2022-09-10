
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_unidade DROP COLUMN orgao_julgador_id;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_unidade ALTER COLUMN unidade_id TYPE bigint;
    ALTER TABLE saj_dsg.regra_distribuicao_unidade ALTER COLUMN unidade_id SET NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao_unidade ALTER COLUMN unidade_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_tarja ALTER COLUMN tarja_id TYPE bigint;
    ALTER TABLE saj_dsg.regra_distribuicao_tarja ALTER COLUMN tarja_id SET NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao_tarja ALTER COLUMN tarja_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_orgao ALTER COLUMN orgao_julgador_id TYPE bigint;
    ALTER TABLE saj_dsg.regra_distribuicao_orgao ALTER COLUMN orgao_julgador_id SET NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao_orgao ALTER COLUMN orgao_julgador_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_orgao ADD unidade_id bigint NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_classe ALTER COLUMN classe_id TYPE bigint;
    ALTER TABLE saj_dsg.regra_distribuicao_classe ALTER COLUMN classe_id SET NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao_classe ALTER COLUMN classe_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao_assunto ALTER COLUMN assunto_id TYPE bigint;
    ALTER TABLE saj_dsg.regra_distribuicao_assunto ALTER COLUMN assunto_id SET NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao_assunto ALTER COLUMN assunto_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN especialidade_id TYPE bigint;
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN especialidade_id DROP NOT NULL;
    ALTER TABLE saj_dsg.regra_distribuicao ALTER COLUMN especialidade_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210629205959_UpdateRegraUnidadeOrgao') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210629205959_UpdateRegraUnidadeOrgao', '3.1.11');
    END IF;
END $$;

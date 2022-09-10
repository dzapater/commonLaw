
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.analise_processo DROP COLUMN area;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.vaga_regra_distribuicao ADD compensacao_por_processo integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.vaga_regra_distribuicao ADD compensacao_por_volume integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.vaga_regra_distribuicao ADD distribuicao_por_processo integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.vaga_regra_distribuicao ADD distribuicao_por_volume integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.vaga ALTER COLUMN motivo TYPE character varying(2000);
    ALTER TABLE saj_dsg.vaga ALTER COLUMN motivo DROP NOT NULL;
    ALTER TABLE saj_dsg.vaga ALTER COLUMN motivo DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.vaga ADD compensacao_por_volume integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.vaga ADD distribuicao_por_volume integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    ALTER TABLE saj_dsg.analise_processo ADD area_atuacao_id bigint NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20211207144526_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao', '3.1.17');
    END IF;
END $$;

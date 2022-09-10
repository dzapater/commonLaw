
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo_log DROP CONSTRAINT fk_distribuicao_processo_log_distribuicao_processo_processo_id;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo DROP CONSTRAINT pk_distribuicao_processo;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    CREATE SCHEMA IF NOT EXISTS saj_dsg;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    CREATE SEQUENCE saj_dsg."DISTRIBUICAO_PROCESSO_ID_SEQ" START WITH 1 INCREMENT BY 10 NO MINVALUE NO MAXVALUE NO CYCLE;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo_log ALTER COLUMN processo_id TYPE character varying(200);
    ALTER TABLE saj_dsg.distribuicao_processo_log ALTER COLUMN processo_id SET NOT NULL;
    ALTER TABLE saj_dsg.distribuicao_processo_log ALTER COLUMN processo_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo_log ADD distribuicao_id bigint NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo ALTER COLUMN processo_id TYPE character varying(200);
    ALTER TABLE saj_dsg.distribuicao_processo ALTER COLUMN processo_id DROP NOT NULL;
    ALTER TABLE saj_dsg.distribuicao_processo ALTER COLUMN processo_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo ADD distribuicao_id bigint NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo ADD vaga_id integer NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo ADD motivo character varying(2000) NULL;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo ADD tipodistribuicao integer NOT NULL DEFAULT 0;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo ADD CONSTRAINT pk_distribuicao_processo PRIMARY KEY (distribuicao_id);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    CREATE INDEX ix_distribuicao_processo_log_distribuicao_id ON saj_dsg.distribuicao_processo_log (distribuicao_id);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    ALTER TABLE saj_dsg.distribuicao_processo_log ADD CONSTRAINT "fk_distribuicao_processo_log_distribuicao_processo_distribuica~" FOREIGN KEY (distribuicao_id) REFERENCES saj_dsg.distribuicao_processo (distribuicao_id) ON DELETE CASCADE;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20211216133522_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao', '3.1.17');
    END IF;
END $$;

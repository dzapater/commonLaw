
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210510194445_CreateAnaliseProceso') THEN
    CREATE TABLE saj_dsg.analise_processo (
        processo_id text NOT NULL,
        vaga_id integer NULL,
        motivo character varying(2000) NULL,
        metadata_uuid uuid NULL,
        metadata_row_version bytea NULL,
        metadata_data_inclusao timestamp with time zone NULL,
        metadata_data_atualizacao timestamp with time zone NULL,
        metadata_usuario_inclusao text NULL,
        metadata_usuario_atualizacao text NULL,
        tipo_distribuicao integer NOT NULL,
        area integer NOT NULL,
        CONSTRAINT pk_analise_processo PRIMARY KEY (processo_id)
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210510194445_CreateAnaliseProceso') THEN
    CREATE UNIQUE INDEX ix_analise_processo_metadata_uuid ON saj_dsg.analise_processo (metadata_uuid);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210510194445_CreateAnaliseProceso') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210510194445_CreateAnaliseProceso', '3.1.11');
    END IF;
END $$;

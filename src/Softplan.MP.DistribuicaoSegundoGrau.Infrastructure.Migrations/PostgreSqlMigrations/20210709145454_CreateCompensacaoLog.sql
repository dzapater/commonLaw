﻿
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210709145454_CreateCompensacaoLog') THEN
    ALTER TABLE saj_dsg.vaga ALTER COLUMN tipo_orgao_id TYPE integer;
    ALTER TABLE saj_dsg.vaga ALTER COLUMN tipo_orgao_id DROP NOT NULL;
    ALTER TABLE saj_dsg.vaga ALTER COLUMN tipo_orgao_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210709145454_CreateCompensacaoLog') THEN
    ALTER TABLE saj_dsg.vaga ALTER COLUMN orgao_id TYPE integer;
    ALTER TABLE saj_dsg.vaga ALTER COLUMN orgao_id DROP NOT NULL;
    ALTER TABLE saj_dsg.vaga ALTER COLUMN orgao_id DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210709145454_CreateCompensacaoLog') THEN
    CREATE TABLE saj_dsg.compensacao_log (
        log_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
        vaga_id integer NOT NULL,
        motivo character varying(2000) NULL,
        metadata_uuid uuid NULL,
        metadata_row_version bytea NULL,
        metadata_data_inclusao timestamp with time zone NULL,
        metadata_data_atualizacao timestamp with time zone NULL,
        metadata_usuario_inclusao text NULL,
        metadata_usuario_atualizacao text NULL,
        valor integer NOT NULL,
        CONSTRAINT pk_compensacao_log PRIMARY KEY (log_id),
        CONSTRAINT fk_compensacao_log_vaga_vaga_id FOREIGN KEY (vaga_id) REFERENCES saj_dsg.vaga (id) ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210709145454_CreateCompensacaoLog') THEN
    CREATE INDEX ix_compensacao_log_vaga_id ON saj_dsg.compensacao_log (vaga_id);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210709145454_CreateCompensacaoLog') THEN
    CREATE UNIQUE INDEX ix_compensacao_log_metadata_uuid ON saj_dsg.compensacao_log (metadata_uuid);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210709145454_CreateCompensacaoLog') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210709145454_CreateCompensacaoLog', '3.1.11');
    END IF;
END $$;
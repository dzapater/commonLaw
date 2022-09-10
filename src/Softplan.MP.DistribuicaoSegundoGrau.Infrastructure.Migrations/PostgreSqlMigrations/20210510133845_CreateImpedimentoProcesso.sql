﻿
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210510133845_CreateImpedimentoProcesso') THEN
    CREATE TABLE saj_dsg.impedimento_processo (
        processo_id integer NOT NULL,
        impedimento_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY,
        metadata_uuid uuid NULL,
        metadata_row_version bytea NULL,
        metadata_data_inclusao timestamp with time zone NULL,
        metadata_data_atualizacao timestamp with time zone NULL,
        metadata_usuario_inclusao text NULL,
        metadata_usuario_atualizacao text NULL,
        vaga_id integer NOT NULL,
        motivo character varying(2000) NULL,
        CONSTRAINT pk_impedimento_processo PRIMARY KEY (processo_id, impedimento_id),
        CONSTRAINT fk_impedimento_processo_vaga_vaga_id FOREIGN KEY (vaga_id) REFERENCES saj_dsg.vaga (id) ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210510133845_CreateImpedimentoProcesso') THEN
    CREATE INDEX ix_impedimento_processo_vaga_id ON saj_dsg.impedimento_processo (vaga_id);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210510133845_CreateImpedimentoProcesso') THEN
    CREATE UNIQUE INDEX ix_impedimento_processo_metadata_uuid ON saj_dsg.impedimento_processo (metadata_uuid);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210510133845_CreateImpedimentoProcesso') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210510133845_CreateImpedimentoProcesso', '3.1.11');
    END IF;
END $$;

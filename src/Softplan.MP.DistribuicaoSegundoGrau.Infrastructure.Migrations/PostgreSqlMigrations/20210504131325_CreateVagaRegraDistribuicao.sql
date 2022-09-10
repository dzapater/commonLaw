
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210504131325_CreateVagaRegraDistribuicao') THEN
    CREATE TABLE saj_dsg.vaga_regra_distribuicao (
        id_vaga integer NOT NULL,
        id_regradistribuicao integer NOT NULL,
        metadata_uuid uuid NULL,
        metadata_row_version bytea NULL,
        metadata_data_inclusao timestamp with time zone NULL,
        metadata_data_atualizacao timestamp with time zone NULL,
        metadata_usuario_inclusao text NULL,
        metadata_usuario_atualizacao text NULL,
        CONSTRAINT pk_vaga_regra_distribuicao PRIMARY KEY (id_vaga, id_regradistribuicao),
        CONSTRAINT "fk_vaga_regra_distribuicao_regra_distribuicao_id_regradistribu~" FOREIGN KEY (id_regradistribuicao) REFERENCES saj_dsg.regra_distribuicao (id) ON DELETE CASCADE,
        CONSTRAINT fk_vaga_regra_distribuicao_vaga_id_vaga FOREIGN KEY (id_vaga) REFERENCES saj_dsg.vaga (id) ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210504131325_CreateVagaRegraDistribuicao') THEN
    CREATE INDEX ix_vaga_regra_distribuicao_id_regradistribuicao ON saj_dsg.vaga_regra_distribuicao (id_regradistribuicao);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210504131325_CreateVagaRegraDistribuicao') THEN
    CREATE UNIQUE INDEX ix_vaga_regra_distribuicao_metadata_uuid ON saj_dsg.vaga_regra_distribuicao (metadata_uuid);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210504131325_CreateVagaRegraDistribuicao') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210504131325_CreateVagaRegraDistribuicao', '3.1.11');
    END IF;
END $$;

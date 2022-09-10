
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210722141836_CreateRegraDistribuicaoEspec') THEN
    CREATE TABLE saj_dsg.regra_distribuicao_espec (
        regra_distribuicao_id integer NOT NULL,
        especialidade_id bigint NOT NULL,
        CONSTRAINT pk_regra_distribuicao_espec PRIMARY KEY (regra_distribuicao_id, especialidade_id),
        CONSTRAINT "fk_regra_distribuicao_espec_regra_distribuicao_regra_distribui~" FOREIGN KEY (regra_distribuicao_id) REFERENCES saj_dsg.regra_distribuicao (id) ON DELETE CASCADE
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210722141836_CreateRegraDistribuicaoEspec') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210722141836_CreateRegraDistribuicaoEspec', '3.1.11');
    END IF;
END $$;

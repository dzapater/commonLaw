
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210617032603_CreateJob') THEN
    CREATE TABLE saj_dsg.jobs (
        id text NOT NULL,
        descricao character varying(200) NULL,
        row_version bytea NULL,
        payload character varying(200) NULL,
        CONSTRAINT pk_jobs PRIMARY KEY (id)
    );
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210617032603_CreateJob') THEN
    INSERT INTO saj_dsg.jobs (id, descricao, payload)
    VALUES ('DistribuicaoVagaJob', 'DistribuicaoVagaJob', '{"LastLogId":0}');
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20210617032603_CreateJob') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20210617032603_CreateJob', '3.1.11');
    END IF;
END $$;

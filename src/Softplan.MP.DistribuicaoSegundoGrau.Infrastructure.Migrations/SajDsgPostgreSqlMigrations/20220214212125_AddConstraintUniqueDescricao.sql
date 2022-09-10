
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM sajdsg."__MigrationsHistory" WHERE "MigrationId" = '20220214212125_AddConstraintUniqueDescricao') THEN
    CREATE UNIQUE INDEX ix_vaga_descricao ON sajdsg.vaga (descricao);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM sajdsg."__MigrationsHistory" WHERE "MigrationId" = '20220214212125_AddConstraintUniqueDescricao') THEN
    INSERT INTO sajdsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220214212125_AddConstraintUniqueDescricao', '3.1.17');
    END IF;
END $$;

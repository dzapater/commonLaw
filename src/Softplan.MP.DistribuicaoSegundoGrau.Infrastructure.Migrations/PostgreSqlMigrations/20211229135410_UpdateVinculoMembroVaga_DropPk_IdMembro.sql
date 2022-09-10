
DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211229135410_UpdateVinculoMembroVaga_DropPk_IdMembro') THEN
    ALTER TABLE saj_dsg.membro_vaga DROP CONSTRAINT pk_membro_vaga;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211229135410_UpdateVinculoMembroVaga_DropPk_IdMembro') THEN
    ALTER TABLE saj_dsg.membro_vaga ALTER COLUMN id_membro TYPE character varying(120);
    ALTER TABLE saj_dsg.membro_vaga ALTER COLUMN id_membro DROP NOT NULL;
    ALTER TABLE saj_dsg.membro_vaga ALTER COLUMN id_membro DROP DEFAULT;
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211229135410_UpdateVinculoMembroVaga_DropPk_IdMembro') THEN
    ALTER TABLE saj_dsg.membro_vaga ADD CONSTRAINT pk_membro_vaga PRIMARY KEY (id, id_vaga);
    END IF;
END $$;

DO $$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM saj_dsg."__MigrationsHistory" WHERE "MigrationId" = '20211229135410_UpdateVinculoMembroVaga_DropPk_IdMembro') THEN
    INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20211229135410_UpdateVinculoMembroVaga_DropPk_IdMembro', '3.1.17');
    END IF;
END $$;

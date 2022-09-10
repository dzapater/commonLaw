DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211229135737_UpdateVinculoMembroVaga_DropPk_IdMembro';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.MEMBRO_VAGA
    DROP PRIMARY KEY
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211229135737_UpdateVinculoMembroVaga_DropPk_IdMembro';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    BEGIN
      EXECUTE IMMEDIATE ''ALTER TABLE SAJ_DSG.MEMBRO_VAGA MODIFY ID_MEMBRO NULL'';
    EXCEPTION
      WHEN OTHERS THEN
        IF SQLCODE <> -1451 AND SQLCODE <> -1442 THEN
          RAISE;
        END IF;
    END;
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211229135737_UpdateVinculoMembroVaga_DropPk_IdMembro';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE MEMBRO_VAGA
     ADD CONSTRAINT PK_MEMBRO_VAGA PRIMARY KEY (ID, ID_VAGA)
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211229135737_UpdateVinculoMembroVaga_DropPk_IdMembro';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20211229135737_UpdateVinculoMembroVaga_DropPk_IdMembro'', ''3.1.17'')
';
  END IF;
END;
/

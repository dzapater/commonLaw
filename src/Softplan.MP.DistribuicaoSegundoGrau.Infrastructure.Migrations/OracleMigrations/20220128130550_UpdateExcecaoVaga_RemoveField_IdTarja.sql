DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20220128130550_UpdateExcecaoVaga_RemoveField_IdTarja';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.EXCECAO_VAGA
    DROP COLUMN "IdTarja"
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20220128130550_UpdateExcecaoVaga_RemoveField_IdTarja';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20220128130550_UpdateExcecaoVaga_RemoveField_IdTarja'', ''3.1.17'')
';
  END IF;
END;
/

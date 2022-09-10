DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJDSG."__MigrationsHistory" WHERE "MigrationId" = '20220214211109_AddConstraintUniqueDescricao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE UNIQUE INDEX IX_VAGA_DESCRICAO ON SAJDSG.VAGA (DESCRICAO)
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJDSG."__MigrationsHistory" WHERE "MigrationId" = '20220214211109_AddConstraintUniqueDescricao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJDSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20220214211109_AddConstraintUniqueDescricao'', ''3.1.17'')
';
  END IF;
END;
/

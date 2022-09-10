DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210520170243_IdEspecialidade';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    BEGIN
      EXECUTE IMMEDIATE ''ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO MODIFY ESPECIALIDADE_ID NULL'';
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
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210520170243_IdEspecialidade';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210520170243_IdEspecialidade'', ''3.1.11'')
';
  END IF;
END;
/

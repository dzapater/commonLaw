DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210726171741_UpdateVagaMotivo';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA
    MODIFY MOTIVO NVARCHAR2(2000) DEFAULT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210726171741_UpdateVagaMotivo';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    BEGIN
      EXECUTE IMMEDIATE ''ALTER TABLE SAJ_DSG.VAGA MODIFY MOTIVO NULL'';
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
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210726171741_UpdateVagaMotivo';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210726171741_UpdateVagaMotivo'', ''3.1.11'')
';
  END IF;
END;
/

DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20220131200523_UpdateRegraDistribuicao_UpdateFields_Area_TipoProcesso';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    BEGIN
      EXECUTE IMMEDIATE ''ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO MODIFY TIPO_PROCESSO NULL'';
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
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20220131200523_UpdateRegraDistribuicao_UpdateFields_Area_TipoProcesso';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    BEGIN
      EXECUTE IMMEDIATE ''ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO MODIFY AREA NULL'';
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
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20220131200523_UpdateRegraDistribuicao_UpdateFields_Area_TipoProcesso';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20220131200523_UpdateRegraDistribuicao_UpdateFields_Area_TipoProcesso'', ''3.1.17'')
';
  END IF;
END;
/

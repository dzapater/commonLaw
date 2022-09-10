DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20220131001734_UpdateRegraDistTarja_addFieldDescricao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO_TARJA
    ADD DESCRICAO NVARCHAR2(120) NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20220131001734_UpdateRegraDistTarja_addFieldDescricao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20220131001734_UpdateRegraDistTarja_addFieldDescricao'', ''3.1.17'')
';
  END IF;
END;
/

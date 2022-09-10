DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210617052903_CreateJob';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE TABLE SAJ_DSG.JOBS ( 
      ID NVARCHAR2(450) NOT NULL,
      DESCRICAO NVARCHAR2(200) NULL,
      ROW_VERSION BLOB NULL,
      PAYLOAD NVARCHAR2(200) NULL,
      PRIMARY KEY (ID)
    )
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210617052903_CreateJob';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG.JOBS (ID, DESCRICAO, PAYLOAD) VALUES (''DistribuicaoVagaJob'', ''DistribuicaoVagaJob'', ''{"LastLogId":0}'')
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210617052903_CreateJob';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210617052903_CreateJob'', ''3.1.11'')
';
  END IF;
END;
/

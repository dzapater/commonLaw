DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210722143301_CreateRegraDistribuicaoEspec';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE TABLE SAJ_DSG.REGRA_DISTRIBUICAO_ESPEC ( 
      REGRA_DISTRIBUICAO_ID NUMBER(10) NOT NULL,
      ESPECIALIDADE_ID NUMBER(19) NOT NULL,
      PRIMARY KEY (REGRA_DISTRIBUICAO_ID, ESPECIALIDADE_ID),
      CONSTRAINT FK_1422020421 FOREIGN KEY (REGRA_DISTRIBUICAO_ID) REFERENCES SAJ_DSG.REGRA_DISTRIBUICAO (ID)
      ON DELETE CASCADE
    )
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210722143301_CreateRegraDistribuicaoEspec';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210722143301_CreateRegraDistribuicaoEspec'', ''3.1.11'')
';
  END IF;
END;
/

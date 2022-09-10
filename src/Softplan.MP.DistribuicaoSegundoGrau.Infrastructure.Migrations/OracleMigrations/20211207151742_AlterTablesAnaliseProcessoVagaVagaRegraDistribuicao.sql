DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.ANALISE_PROCESSO
    DROP COLUMN AREA
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA_REGRA_DISTRIBUICAO
    ADD COMPENSACAO_POR_PROCESSO NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA_REGRA_DISTRIBUICAO
    ADD COMPENSACAO_POR_VOLUME NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA_REGRA_DISTRIBUICAO
    ADD DISTRIBUICAO_POR_PROCESSO NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA_REGRA_DISTRIBUICAO
    ADD DISTRIBUICAO_POR_VOLUME NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA
    ADD COMPENSACAO_POR_VOLUME NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA
    ADD DISTRIBUICAO_POR_VOLUME NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.ANALISE_PROCESSO
    ADD AREA_ATUACAO_ID NUMBER(19) NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20211207151742_AlterTablesAnaliseProcessoVagaVagaRegraDistribuicao'', ''3.1.17'')
';
  END IF;
END;
/

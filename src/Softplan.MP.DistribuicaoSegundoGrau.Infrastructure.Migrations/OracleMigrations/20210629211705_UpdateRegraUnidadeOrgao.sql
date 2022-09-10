DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO_UNIDADE
    DROP COLUMN ORGAO_JULGADOR_ID
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO_UNIDADE
    MODIFY UNIDADE_ID NUMBER(19) DEFAULT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO_TARJA
    MODIFY TARJA_ID NUMBER(19) DEFAULT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO_ORGAO
    MODIFY ORGAO_JULGADOR_ID NUMBER(19) DEFAULT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO_ORGAO
    ADD UNIDADE_ID NUMBER(19) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO_CLASSE
    MODIFY CLASSE_ID NUMBER(19) DEFAULT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO_ASSUNTO
    MODIFY ASSUNTO_ID NUMBER(19) DEFAULT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.REGRA_DISTRIBUICAO
    MODIFY ESPECIALIDADE_ID NUMBER(19) DEFAULT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210629211705_UpdateRegraUnidadeOrgao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210629211705_UpdateRegraUnidadeOrgao'', ''3.1.11'')
';
  END IF;
END;
/

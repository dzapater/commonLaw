﻿DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210510194245_CreateAnaliseProcesso';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE TABLE SAJ_DSG.ANALISE_PROCESSO ( 
      PROCESSO_ID NVARCHAR2(450) NOT NULL,
      VAGA_ID NUMBER(10) NULL,
      MOTIVO NVARCHAR2(2000) NULL,
      METADATA_UUID RAW(16) NULL,
      METADATA_ROW_VERSION BLOB NULL,
      METADATA_DATA_INCLUSAO TIMESTAMP(7) WITH TIME ZONE NULL,
      METADATA_DATA_ATUALIZACAO TIMESTAMP(7) WITH TIME ZONE NULL,
      METADATA_USUARIO_INCLUSAO NCLOB NULL,
      METADATA_USUARIO_ATUALIZACAO NCLOB NULL,
      TIPO_DISTRIBUICAO NUMBER(10) NOT NULL,
      AREA NUMBER(10) NOT NULL,
      PRIMARY KEY (PROCESSO_ID)
    )
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210510194245_CreateAnaliseProcesso';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE UNIQUE INDEX IX_328778418 ON SAJ_DSG.ANALISE_PROCESSO (METADATA_UUID)
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210510194245_CreateAnaliseProcesso';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210510194245_CreateAnaliseProcesso'', ''3.1.11'')
';
  END IF;
END;
/
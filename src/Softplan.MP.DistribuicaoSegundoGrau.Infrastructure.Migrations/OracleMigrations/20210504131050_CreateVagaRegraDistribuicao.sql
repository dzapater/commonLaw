﻿DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210504131050_CreateVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE TABLE SAJ_DSG.VAGA_REGRA_DISTRIBUICAO ( 
      ID_VAGA NUMBER(10) NOT NULL,
      ID_REGRADISTRIBUICAO NUMBER(10) NOT NULL,
      METADATA_UUID RAW(16) NULL,
      METADATA_ROW_VERSION BLOB NULL,
      METADATA_DATA_INCLUSAO TIMESTAMP(7) WITH TIME ZONE NULL,
      METADATA_DATA_ATUALIZACAO TIMESTAMP(7) WITH TIME ZONE NULL,
      METADATA_USUARIO_INCLUSAO NCLOB NULL,
      METADATA_USUARIO_ATUALIZACAO NCLOB NULL,
      PRIMARY KEY (ID_VAGA, ID_REGRADISTRIBUICAO),
      CONSTRAINT FK_N1010648161 FOREIGN KEY (ID_REGRADISTRIBUICAO) REFERENCES SAJ_DSG.REGRA_DISTRIBUICAO (ID)
      ON DELETE CASCADE,
      CONSTRAINT FK_362469444 FOREIGN KEY (ID_VAGA) REFERENCES SAJ_DSG.VAGA (ID)
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
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210504131050_CreateVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE INDEX IX_1817585890 ON SAJ_DSG.VAGA_REGRA_DISTRIBUICAO (ID_REGRADISTRIBUICAO)
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210504131050_CreateVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE UNIQUE INDEX IX_133238020 ON SAJ_DSG.VAGA_REGRA_DISTRIBUICAO (METADATA_UUID)
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210504131050_CreateVagaRegraDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210504131050_CreateVagaRegraDistribuicao'', ''3.1.11'')
';
  END IF;
END;
/
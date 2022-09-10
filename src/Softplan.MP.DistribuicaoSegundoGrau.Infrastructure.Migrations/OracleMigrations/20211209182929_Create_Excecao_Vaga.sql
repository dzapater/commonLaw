﻿DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211209182929_Create_Excecao_Vaga';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE TABLE SAJ_DSG.EXCECAO_VAGA ( 
      ID NUMBER(19) NOT NULL,
      METADATA_UUID RAW(16) NULL,
      METADATA_ROW_VERSION BLOB NULL,
      METADATA_DATA_INCLUSAO TIMESTAMP(7) WITH TIME ZONE NULL,
      METADATA_DATA_ATUALIZACAO TIMESTAMP(7) WITH TIME ZONE NULL,
      METADATA_USUARIO_INCLUSAO NCLOB NULL,
      METADATA_USUARIO_ATUALIZACAO NCLOB NULL,
      VAGA_ID NUMBER(10) NOT NULL,
      CLASSE_ID NUMBER(10) NULL,
      ASSUNTO_ID NUMBER(10) NULL,
      ESPECIALIDADE_ID NUMBER(10) NULL,
      ORIGEM_ID NUMBER(10) NULL,
      UNIDADE_ID NUMBER(10) NULL,
      ORGAO_JULGADOR_ID NUMBER(10) NULL,
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
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211209182929_Create_Excecao_Vaga';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE SEQUENCE SAJ_DSG.EXCECAO_VAGA_SEQ
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211209182929_Create_Excecao_Vaga';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE OR REPLACE TRIGGER SAJ_DSG.EXCECAO_VAGA_INS_TRG
      BEFORE INSERT ON SAJ_DSG.EXCECAO_VAGA
      FOR EACH ROW
    BEGIN
      SELECT SAJ_DSG.EXCECAO_VAGA_SEQ.NEXTVAL INTO :NEW.ID FROM DUAL;
    END;
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211209182929_Create_Excecao_Vaga';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE UNIQUE INDEX IX_EXCECAO_VAGA_METADATA_UUID ON SAJ_DSG.EXCECAO_VAGA (METADATA_UUID)
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211209182929_Create_Excecao_Vaga';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20211209182929_Create_Excecao_Vaga'', ''3.1.17'')
';
  END IF;
END;
/
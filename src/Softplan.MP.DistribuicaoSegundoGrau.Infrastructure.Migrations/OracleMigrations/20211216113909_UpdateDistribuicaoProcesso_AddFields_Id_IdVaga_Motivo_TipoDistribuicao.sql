DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO_LOG
    DROP CONSTRAINT FK_N1194527237
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO
    DROP PRIMARY KEY
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE SEQUENCE SAJ_DSG.DISTRIBUICAO_PROCESSO_ID_SEQ
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    BEGIN
      EXECUTE IMMEDIATE ''ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO_LOG MODIFY PROCESSO_ID NOT NULL'';
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
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO_LOG
    ADD DISTRIBUICAO_ID NUMBER(19) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    BEGIN
      EXECUTE IMMEDIATE ''ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO MODIFY PROCESSO_ID NULL'';
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
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO
    ADD DISTRIBUICAO_ID NUMBER(19) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE OR REPLACE TRIGGER SAJ_DSG.TRG_DISTRIBUICAO_ID
                          BEFORE INSERT ON SAJ_DSG.DISTRIBUICAO_PROCESSO
                          FOR EACH ROW
                            BEGIN
                              SELECT SAJ_DSG.DISTRIBUICAO_PROCESSO_ID_SEQ.NEXTVAL INTO :NEW.DISTRIBUICAO_ID FROM DUAL;
                            END;
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO
    ADD VAGA_ID NUMBER(10) NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO
    ADD MOTIVO NVARCHAR2(2000) NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO
    ADD TIPODISTRIBUICAO NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO
     ADD CONSTRAINT PK_DISTRIBUICAO_PROCESSO PRIMARY KEY (DISTRIBUICAO_ID)
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    CREATE INDEX IX_N1611352809 ON SAJ_DSG.DISTRIBUICAO_PROCESSO_LOG (DISTRIBUICAO_ID)
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.DISTRIBUICAO_PROCESSO_LOG
      ADD CONSTRAINT FK_1223515613 FOREIGN KEY (DISTRIBUICAO_ID) REFERENCES SAJ_DSG.DISTRIBUICAO_PROCESSO (DISTRIBUICAO_ID)
      ON DELETE CASCADE
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20211216113909_UpdateDistribuicaoProcesso_AddFields_Id_IdVaga_Motivo_TipoDistribuicao'', ''3.1.17'')
';
  END IF;
END;
/

﻿DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210618105431_UpdateVaga';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA
    ADD COMPENSACAO NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210618105431_UpdateVaga';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    ALTER TABLE SAJ_DSG.VAGA
    ADD DISTRIBUICOES NUMBER(10) DEFAULT 0 NOT NULL
';
  END IF;
END;
/
DECLARE
  pCount NUMBER;
BEGIN
  pCount := 0;
  SELECT count(*) INTO pCount FROM SAJ_DSG."__MigrationsHistory" WHERE "MigrationId" = '20210618105431_UpdateVaga';
  IF (pCount <> 1) THEN
    EXECUTE IMMEDIATE '
    INSERT INTO SAJ_DSG."__MigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES (''20210618105431_UpdateVaga'', ''3.1.11'')
';
  END IF;
END;
/

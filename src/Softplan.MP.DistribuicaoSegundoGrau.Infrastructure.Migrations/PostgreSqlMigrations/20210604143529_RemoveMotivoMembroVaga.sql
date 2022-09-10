ALTER TABLE saj_dsg.membro_vaga DROP CONSTRAINT fk_membro_vaga_motivo_membro_vaga_id_motivo_membro_vaga;

DROP TABLE saj_dsg.motivo_membro_vaga;

DROP INDEX saj_dsg.ix_membro_vaga_id_motivo_membro_vaga;

INSERT INTO saj_dsg."__MigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20210604143529_RemoveMotivoMembroVaga', '3.1.11');


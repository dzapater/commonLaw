# mp-distribuicao-segundo-grau-api

- [Documentação](https://git-unj.softplan.com.br/saj/mp/mp-distribuicao/mp-distribuicao-segundo-grau-api/wikis/home)

- [Sonar](https://sonar-unj.softplan.com.br/dashboard?id=mp-distribuicao-segundo-grau-api)

## Dependências e Variáveis

As dependências externas e os respectivos nós da configuração (`appsettings.json`) ou variáveis de ambiente são:

| Chave                       | Valor                                                                                                            |
|-----------------------------|------------------------------------------------------------------------------------------------------------------|
| CONNECTION_STRING           | <<Definir base>>                                                                                                 |
| DATABASE_PROVIDER           | Oracle | Postgres | SQLServer                                                                                    |
| BASE_PATH                   | /mp-distribuicao-segundo-grau-api

---

## Service Level Objectives
### Dependências

| Sub-Sistema       | Mandatório? |
|-------------------|-------------|
| KeyCloak          | S           |
| DataBase          | S           |
| Redis             | N           |
| APM               | N           |
| Storage           | N           |


## Definições de SLO

| Métrica                             | Valor   |
|-------------------------------------|---------|
| Disponibilidade Interna             | 90%     |
| Média do tempo de request outbound  | 300ms   |
| Média do tempo de request inbound   | 10s     |

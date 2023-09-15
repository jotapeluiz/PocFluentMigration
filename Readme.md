
# Poc Fluent Migrator

Aplicação ASP .Net Core MVC para testar o uso da biblioteca [FluentMigrator](https://fluentmigrator.github.io/)

## Configuração Bando de Dados

Caso use Docker pode subir as instâncias MySQL, PostgreSQL e SQL Server basta rodar o comando:

```
docker-compose up
```

Os arquivo `docker-compose.yml` e `appsettings.json` já está configurado para usar as configurações via docker.

Para subir a aplicação basta rodar o comando:
```
dotnet run
```

Uma vez executada a aplicação deverá criar uma base de dados chamada **BrazilianCities** com as tabelas: **Countries**, **States** e **VersionInfo** além de já as deixar populadas.

## Observação

Por conta de sintaxe de banco de dados pode ser que a aplicação apresente erro ao exibir no navegador porém o intuito desse projeto foi avaliar a criação de tabelas de forma automatizada.
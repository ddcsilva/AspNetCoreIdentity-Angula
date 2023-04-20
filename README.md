# AspNetCoreIdentity-Angular

Este projeto é um exemplo de como criar uma API usando o ASP.NET Core 5 com o Identity para gerenciar usuários e funções e um aplicativo Angular 12 para consumir a API.

## Recursos

- API em .NET 5 com autenticação e autorização usando o ASP.NET Core Identity
- Aplicativo Angular 12 com gerenciamento de usuários e funções
- Integração com o Entity Framework Core e SQL Server LocalDB
- Autenticação baseada em JWT

## Estrutura do projeto

- Sistema.API: API em .NET 5 com controladores e serviços para gerenciar usuários e funções
- Sistema.Core: Biblioteca de classes .NET com entidades e contexto do banco de dados
- Sistema.UI: Aplicativo Angular 12 com componentes e serviços para interagir com a API

## Configuração e execução

1. Instale o .NET 5 SDK e o Angular CLI 12
2. Clone o repositório e navegue até a pasta do projeto
3. Execute `dotnet restore` para restaurar os pacotes .NET
4. Execute `dotnet ef database update` para aplicar as migrações e criar o banco de dados
5. Execute `dotnet run` na pasta Sistema.API para iniciar a API
6. Navegue até a pasta Sistema.UI e execute `npm install` para instalar os pacotes npm
7. Execute `ng serve` para iniciar o aplicativo Angular
8. Abra o navegador e vá para `http://localhost:4200` para acessar o aplicativo

## Licença

Este projeto é licenciado sob a licença MIT.

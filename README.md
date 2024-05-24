# ClientesApp

ClientesApp é uma API ASP.NET que implementa um CRUD (Create, Read, Update, Delete) de clientes. O projeto segue a arquitetura DDD (Domain-Driven Design) e é dividido em três projetos principais:

1. **ClientesApp.API**: Este é o projeto da API, responsável por expor os endpoints HTTP.
2. **ClientesApp.Domain**: Este projeto contém a lógica de negócios e as entidades do domínio.
3. **ClientesApp.Infra.Data**: Este projeto é responsável pela persistência de dados, utilizando o Entity Framework para interagir com o banco de dados.

## Banco de Dados

O projeto utiliza o Entity Framework para interagir com o banco de dados chamado `BDClientesApp`.

## Como executar o projeto

1. Clone o repositório para a sua máquina local.
2. Navegue até a pasta do projeto e execute o comando `dotnet restore` para restaurar as dependências do projeto.
3. Execute o comando `dotnet run` na pasta `ClientesApp.API` para iniciar a API.
4. A API estará disponível no endereço `http://localhost:5000`.

## Endpoints

A API expõe os seguintes endpoints para manipulação dos dados de clientes:

- `GET /clientes`: Retorna todos os clientes.
- `GET /clientes/{id}`: Retorna o cliente com o ID especificado.
- `POST /clientes`: Cria um novo cliente.
- `PUT /clientes/{id}`: Atualiza o cliente com o ID especificado.
- `DELETE /clientes/{id}`: Deleta o cliente com o ID especificado.

## Contribuição

Contribuições são bem-vindas. Por favor, abra uma issue para discutir o que você gostaria de mudar ou adicionar.

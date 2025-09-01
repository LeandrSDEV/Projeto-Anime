#####    Projeto Anime API    #####

API RESTful desenvolvida em .NET para gerenciamento de animes, com suporte a filtros, documentação via Swagger, testes automatizados e deploy com Docker. O projeto segue o padrão de **Clean Architecture** e utiliza **Entity Framework Core** com **SQL Server**.

# Funcionalidades

- Listar todos os animes
- Buscar animes por **ID**, **nome**, **diretor** (com combinação entre filtros)
- Criar novo anime
- Atualizar anime existente
- Excluir anime
- Versionamento de rotas (`/api/v1`)
- Documentação interativa via Swagger
- Logs com Serilog
- Testes unitários com xUnit
- Deploy com Docker e Docker Compose

---

# Arquitetura

O projeto segue o padrão de **Clean Architecture**, com separação de responsabilidades por camadas:

- `ProjetoAnime.Application`: Casos de uso (Commands e Queries) + MediatR
- `ProjetoAnime.Core`: Entidades e interfaces
- `ProjetoAnime.Infrastructure`: Repositórios, contexto EF e migrations
- `ProjetoAnime`: Camada de API (Controllers, Middlewares, etc)
- `ProjetoAnime.Tests`: Testes de unidade com xUnit

# Tecnologias utilizadas

- .NET (versão mais atual)
- Entity Framework Core (SQL Server)
- MediatR
- Serilog
- xUnit
- Swagger
- Docker + Docker Compose

# Como rodar a aplicação

• Rodar com Docker Compose (recomendado)

Clone o repositório (caso ainda não tenha feito):
 
Suba a aplicação com Docker Compose:

docker-compose up --build

 • Acesse o serviço:

Swagger: http://localhost:5000/swagger

O banco de dados será criado automaticamente com as migrations aplicadas.

### 🐳 Rodando com Docker Compose (recomendado)

```bash
docker-compose up --build

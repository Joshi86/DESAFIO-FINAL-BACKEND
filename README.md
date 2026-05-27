1. Descrição do Projeto

O SchoolManager é uma aplicação web para gestão escolar desenvolvida para controle de alunos, professores, disciplinas e notas. O sistema permite operações básicas de CRUD (criação, leitura, atualização e exclusão), além do lançamento e consulta de notas associadas a alunos e disciplinas.

A arquitetura é baseada em uma API backend em .NET, consumida por uma interface web estática (HTML, CSS e JavaScript), com persistência de dados em banco PostgreSQL hospedado no Supabase.

2. Tecnologias Utilizadas
   
Linguagem:
C#
JavaScript
HTML5 / CSS3
Framework:
ASP.NET Core (Web API)
Entity Framework Core
Bootstrap 5
Banco de Dados:
PostgreSQL (Supabase)
Segurança:
Autenticação via JWT (JSON Web Token)
Controle de sessão via localStorage no frontend
Validação de dados no backend e frontend
Documentação de API:
Swagger (OpenAPI)

3. Instruções de Execução

Para rodar o projeto localmente, siga os passos abaixo:

Clonar o repositório do projeto

Restaurar as dependências do backend (.NET):

dotnet restore
Configurar a connection string do banco de dados no arquivo appsettings.json

Aplicar as migrations no banco de dados:

dotnet ef database update

Executar a aplicação:

dotnet run
Abrir o frontend (HTML) em um navegador ou via Live Server (VS Code)

4. Endpoints da API

Abaixo estão os principais endpoints disponíveis no sistema:

Alunos
GET /api/alunos
Retorna todos os alunos cadastrados.
GET /api/alunos/{id}
Retorna um aluno específico.
POST /api/alunos
Cadastra um novo aluno.
PUT /api/alunos/{id}
Atualiza os dados de um aluno.
DELETE /api/alunos/{id}
Remove um aluno.
Professores
GET /api/professores
Lista todos os professores.
Disciplinas
GET /api/disciplinas
Lista todas as disciplinas.
POST /api/disciplinas
Cadastra uma nova disciplina.
Notas
GET /api/notas/{alunoId}
Lista todas as notas de um aluno.
POST /api/notas
Lança uma nota para um aluno em uma disciplina.

# 👨‍💻 Autor

Desenvolvido por Joshi.

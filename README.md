#  Sistema Escolar Fullstack

Sistema escolar fullstack desenvolvido com ASP.NET Core, MySQL, JavaScript e Bootstrap.

O sistema permite:

- Cadastro de usuários
- Login com autenticação JWT
- Cadastro de alunos
- Cadastro de disciplinas
- Lançamento de notas
- Visualização de notas
- CRUD completo de alunos
- Integração frontend + backend
- Persistência de dados no MySQL

---

#  Tecnologias Utilizadas

## Backend
- ASP.NET Core
- Entity Framework Core
- JWT Authentication
- Swagger
- MySQL

## Frontend
- HTML5
- CSS3
- JavaScript
- Bootstrap 5

---

#  Autenticação

O sistema utiliza autenticação JWT.

Após realizar login:
- o backend gera um token JWT;
- o token é salvo no localStorage;
- as rotas protegidas utilizam Authorization Bearer Token.

O cadastro e login dos usuários são armazenados no banco de dados MySQL.

---

#  Banco de Dados

Banco utilizado:

- MySQL

Tabelas principais:
- Alunos
- Disciplinas
- Matrículas
- Usuários

---

#  Funcionalidades

## Alunos
- Criar aluno
- Editar aluno
- Excluir aluno
- Listar alunos

## Disciplinas
- Criar disciplina

## Notas
- Lançar notas
- Ver notas dos alunos

## Usuários
- Cadastro
- Login
- JWT

---

#  Validações

O sistema possui validações no frontend para:
- CPF inválido
- Nota maior que 10
- Campos vazios
- Login inválido
- Cadastro inválido

---

# ▶️ Como Executar

## 1. Clonar o projeto

```bash
git clone https://github.com/Joshi86/SISTEMA-ESCOLAR-FULLSTACK
```

## 2. Abrir no Visual Studio

Abra o arquivo `.sln`

---

## 3. Configurar o banco de dados (Se o seu nome for Marcelo e você for monitor de uma turma aí não precisa fazer isso, já está configurado)

Edite o `appsettings.json`:

```json
"ConnectionStrings": {
  "ConexaoPadrao": "Server=localhost;Database=AlunosDB;Uid=root;Pwd=SUA_SENHA;"
}
```

---

## 4. Executar migrations

```bash
Update-Database
```

---

## 5. Rodar o projeto

Pressione:

```txt
F5
```

ou:

```bash
dotnet run
```

---

# 👨‍💻 Autor

Desenvolvido por Joshi.

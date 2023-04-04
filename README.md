# CustomerMicroservice

Projeto desenvolvido para implentação de conceitos de Microserviços, Testes, Dependency Injection, etc.

A solução está divida de acordo com os projeto abaixo:

### API
Projeto responsável pela interface com o usuário contendo os endpoints de inclusão, listagem, exclução e alteração de dados.

### Business
Camada responsável pelos modelos e, futuramente, serviços.

### Data
Camada responsável pelos acessos ao banco de dados.

### Testes
Contém testes unitários e testes integrados (incluindo banco de dados em memória)



## Instalação

No Visual Studio, abra o Package Manager Console e selecione o projeto **DATA** 

```bash
  Update-Database
```
    
No Visual Studio Code, execute em `CustomerMicroservice\src\API>`
```bash
  dotnet ef database update -c ApplicationDbContext
```

Será criado o diretório SQLite no projeto API com o banco de dados chamado Mentoria.sqlite.

Ao rodar o projeto pela primeira vez, serão inseridos dados na tabela Customers

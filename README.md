# NimbusApi

## Visão Geral

O **NimbusApi** é uma API REST desenvolvida em .NET para gerenciamento de alertas de desastres meteorológicos, usuários, localizações, endereços e entidades relacionadas. O sistema permite o cadastro, consulta, atualização e remoção de informações essenciais para o funcionamento de um aplicativo de alertas.

## Estrutura do Projeto

- **Controllers/**: Camada de entrada da API, responsável por receber e responder às requisições HTTP.
- **Models/**: Classes que representam as entidades do domínio (ex: Usuario, Alerta, Bairro, Estado, etc).
- **Services/**: Camada de lógica de negócio, responsável por validar e processar as operações.
- **Repository/**: Camada de acesso a dados, responsável pela comunicação com o banco de dados.
- **Validations/**: Classes de validação para garantir integridade dos dados.
- **Connection/**: Configuração do contexto do banco de dados (Entity Framework).
- **Exceptions/**: Exceções customizadas para tratamento de erros.

## Desenvolvimento

O projeto utiliza o **Entity Framework Core** para acesso a dados e segue o padrão de arquitetura em camadas (Controller → Service → Repository).

### Principais Funcionalidades

- Cadastro, consulta, atualização e remoção de usuários, alertas, endereços, bairros, cidades, estados, países e grupos de endereço.
- Validações robustas para garantir integridade dos dados.
- Tratamento de exceções customizadas para respostas claras ao cliente.

### Tecnologias Utilizadas

- .NET 9.0
- Entity Framework Core
- Oracle Database (conforme string de conexão em `appsettings.json`)
- ASP.NET Core Web API

## Instruções para Acesso

### Pré-requisitos

- .NET SDK 9.0 ou superior
- Acesso ao banco de dados Oracle (ajuste a string de conexão em `NimbusApi/appsettings.json` se necessário)

### Como Executar

1. Clone o repositório:
    ```sh
    git clone https://github.com/GSNimbus/DotNet
    cd NimbusApi/NimbusApi
    ```

2. Restaure os pacotes e compile:
    ```sh
    dotnet restore
    dotnet build
    ```

3. Execute a aplicação:
    ```sh
    dotnet run
    ```

4. Acesse a API via [http://localhost:5000](http://localhost:5000) (ou porta configurada).

### Endpoints Principais

- `GET https://localhost:7216/api/Usuario` — Lista todos os usuários
- `POST https://localhost:7216/api/Alerta` — Cria um novo alerta
- `GET https://localhost:7216/api/Endereco/cep/{cep}` — Busca endereço pelo CEP
- `POST https://localhost:7216/api/Bairro` — Cria um novo bairro
- `POST https://localhost:7216/api/Estado` — Cria um novo estado
- `POST https://localhost:7216/api/Cidade` — Cria uma nova cidade

Consulte os controllers para mais endpoints.

## Testes

### Exemplos de Teste Manual

Você pode testar os endpoints utilizando ferramentas como **Swagger** ou **curl**.

#### Exemplo: Criar um novo usuário

```http
POST https://localhost:7216/api/Usuario
Content-Type: application/json

{
  "nome": "João Silva",
  "email": "joao@email.com",
  "senha": "senha123",
  "idLocalizacao": 1
}
```

#### Exemplo: Buscar endereço por CEP

```http
GET https://localhost:7216/api/Endereco/cep/12345-678
```

#### Exemplo: Criar um novo alerta

```http
POST https://localhost:7216/api/Alerta
Content-Type: application/json

{
  "risco": "Alto",
  "descricao": "Tempestade forte",
  "mensagem": "Evite sair de casa",
  "dataHora": "2024-06-01T15:00:00",
  "idLocalizacao": 1
}
```


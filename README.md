# 🚀 TrilhaNetAzureDesafio

![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet?style=for-the-badge)
![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp)
![Azure](https://img.shields.io/badge/Hosted%20on-Azure-blue?style=for-the-badge&logo=microsoftazure)
![Status](https://img.shields.io/badge/Status-Online-success?style=for-the-badge)

## 📘 Sobre o Projeto

O **TrilhaNetAzureDesafio** é uma **API minimalista em .NET 9** desenvolvida como parte de um **desafio prático da DIO (Digital Innovation One)**.  
Seu objetivo é demonstrar a criação, estruturação e publicação de uma **Web API moderna** utilizando **Entity Framework Core** e **Swagger** — e, posteriormente, realizar o **deploy completo no Microsoft Azure App Service**.

> 💡 Essa API foi criada inicialmente para rodar localmente, mas atualmente está **publicada na nuvem** e acessível publicamente.

<img width="1351" height="603" alt="Mostrando a API com Swagger, com os comandos HTTP" src="https://github.com/user-attachments/assets/0bc2c6d7-3615-4914-9a08-eb9475119d96" />

---

## 🌐 Acesso Online

A API está disponível em produção no **Azure App Service** (realizei duas versões para caso de estudo):  

Versão 1: **[Acesse aqui o Swagger](https://desafioazuredio-dka4c2ddcvh4e6a6.brazilsouth-01.azurewebsites.net/swagger/index.html)**

Versão 2: **[Acesse aqui o Swagger](https://desafioprojetovideo-akc9f7gueee2fye9.brazilsouth-01.azurewebsites.net/swagger/index.html)**

---

## 🧩 Tecnologias Utilizadas

| Categoria | Ferramenta / Tecnologia |
|------------|--------------------------|
| Linguagem | C# |
| Framework | .NET 9 |
| ORM | Entity Framework Core |
| Documentação | Swagger / Swashbuckle |
| Banco de Dados | SQL Server (local) |
| Hospedagem | Azure App Service |
| IDE | Visual Studio Code |
| Deploy | Azure Tools for VS Code |

---

## 🧩 Integração com Banco de Dados Azure SQL

Durante o projeto, foi criada uma base de dados **SQL Server hospedada no Azure** para armazenar informações da tabela **Funcionarios**.  
A integração foi feita de forma prática, utilizando as extensões e configurações adequadas para conectar a API ao banco em nuvem.

### ⚙️ Etapas Realizadas

1. **Criação do Banco de Dados no Azure**
   - Banco: `SistemaRH`
   - Servidor: `desafioazureapi.database.windows.net`

2. **Criação da Tabela Funcionarios**
   ```sql
   CREATE TABLE Funcionarios (
       Id INT PRIMARY KEY IDENTITY(1,1),
       Nome NVARCHAR(100) NOT NULL,
       Endereco NVARCHAR(200),
       Ramal NVARCHAR(20),
       EmailProfissional NVARCHAR(100),
       Departamento NVARCHAR(50),
       Salario DECIMAL(18,2),
       DataAdmissao DATETIMEOFFSET
   );
   ```

3. Inserção de Dados de Exemplo
   ```sql
   INSERT INTO Funcionarios (Nome, Endereco, Ramal, EmailProfissional, Departamento, Salario, DataAdmissao) 
   VALUES 
   ('Ana Silva', 'Rua das Flores, 100', '1001', 'ana.silva@empresa.com', 'TI', 5500.00, '2024-01-10'),
   ('Pedro Costa', 'Av. Brasil, 200', '1002', 'pedro.costa@empresa.com', 'Vendas', 4800.00, '2024-02-15'),
   ('Mariana Lima', 'Rua Central, 300', '1003', 'mariana.lima@empresa.com', 'RH', 4200.00, '2024-03-20');

   ```

4. Extensão usada no VS Code
   - SQL Server (mssql) — para conectar e executar queries diretamente no banco do Azure.

5. Configuração da Conexão no App Service
   ````pgsql
   ConnectionStrings__ConexaoPadrao = Server=tcp:<<NOME_DO_SERVIDOR>>.database.windows.net,1433;
   Initial Catalog=<<NOME_DO_BANCO>>;
   Persist Security Info=False;
   User ID=<<USUARIO_ADMIN>>;
   Password=<<SENHA_FORTE>>;
   MultipleActiveResultSets=False;
   Encrypt=True;
   TrustServerCertificate=False;
   Connection Timeout=30;
   ````

6. Resultado
   - A API passou a salvar e consultar os dados diretamente no Azure SQL Server, sem depender de um banco local.

    **Versão 1:**

   <div align="center">
   <img width="775" height="437" alt="Versão 1: Consulta da tabela no banco de dados no Azure" src="https://github.com/user-attachments/assets/df17925a-0f70-4984-a9c1-842c907b8b81" />
   </div>

   **Versão 2:**

   
   <div align="center">
   <img width="816" height="393" alt="Versão 2: Consulta da tabela no banco de dados no Azure" src="https://github.com/user-attachments/assets/b98b3921-4909-4b07-952f-fb94bf84bc76" />
   </div>

---

## 🧠 Diagrama de Arquitetura (Exemplo)

   ```mermaid
   graph TD
   A[Cliente / Navegador] --> B[API - TrilhaNetAzureDesafio]
   B --> C[Controllers]
   C --> D[Entity Framework Core]
   D --> E[Azure SQL Database]
   B --> G[Swagger UI]
   ````

> 💡 O diagrama acima representa o fluxo principal de requisições HTTP processadas pela API, com integração direta ao banco de dados no Azure.

## ⚙️ Como Executar Localmente

**Pré-requisitos**

Antes de rodar o projeto, certifique-se de ter:

- .NET SDK 9.0;
- Visual Studio Code;
- Extensão C# e Azure Tools;
- SQL Server (ou LocalDB).

## ▶️ Passos para executar

`````
# Clone este repositório
git clone https://github.com/SeuUsuario/TrilhaNetAzureDesafio.git

# Entre na pasta do projeto
cd TrilhaNetAzureDesafio

# Restaure os pacotes
dotnet restore

# Rode a aplicação
dotnet run
``````

## ☁️ Deploy no Microsoft Azure

### 📦 Processo de Deploy (resumo do que foi feito)

1. Publicação local:

   ````
   dotnet publish
   ````
Arquivos gerados em **/bin/Release/net9.0/publish**

2. Extensão usada:
  - Azure App Service (Microsoft)

3. Passos no VS Code:
   - Entrar na aba Azure (ícone à esquerda)
   - Conectar com sua conta do GitHub/Azure
   - Criar um novo App Service
   - Escolher o nome: desafioazuredio
   - Escolher a região: Brazil South
   - Selecionar a pasta /publish
   - Confirmar o deploy

4. Resultado:
   - API hospedada e disponível publicamente 💙

---

## 📚 Aprendizados do Projeto

- Como criar, configurar e publicar uma API minimalista em .NET 9;
- Utilizar o Entity Framework Core para persistência de dados;
- Documentar e testar endpoints com Swagger;
- Fazer deploy completo no Azure App Service via VS Code;
- Criar e conectar um banco de dados SQL Server no Azure usando a extensão mssql;
- Configurar Connection Strings no App Service;
- Realizar consultas SQL diretamente pelo VS Code e exportar resultados em JSON;
- Entender o fluxo de integração entre aplicação e banco em nuvem.

---

## 📦 Exemplo de Dados do Banco (JSON Export)

Este é o resultado obtido ao exportar os dados da tabela Funcionarios diretamente do Azure SQL Database para JSON:

```json
[
  {
    "Id": "1",
    "Nome": "Ana Silva",
    "Endereco": "Rua das Flores, 100",
    "Ramal": "1001",
    "EmailProfissional": "ana.silva@empresa.com",
    "Departamento": "TI",
    "Salario": "5500.00",
    "DataAdmissao": "2024-01-10T00:00:00.0000000+00:00"
  },
  {
    "Id": "2",
    "Nome": "Pedro Costa",
    "Endereco": "Av. Brasil, 200",
    "Ramal": "1002",
    "EmailProfissional": "pedro.costa@empresa.com",
    "Departamento": "Vendas",
    "Salario": "4800.00",
    "DataAdmissao": "2024-02-15T00:00:00.0000000+00:00"
  },
  {
    "Id": "3",
    "Nome": "Mariana Lima",
    "Endereco": "Rua Central, 300",
    "Ramal": "1003",
    "EmailProfissional": "mariana.lima@empresa.com",
    "Departamento": "RH",
    "Salario": "4200.00",
    "DataAdmissao": "2024-03-20T00:00:00.0000000+00:00"
  }
]
```

> Essa exportação demonstra que a API está efetivamente conectada ao banco de dados hospedado no Azure SQL, permitindo visualizar e manipular os dados remotamente.

## 🧑‍💻 Autora

**Stephanie Tavares dos Santos**

🔗 [LinkedIn](https://www.linkedin.com/in/stephanie-t-santos/)  

💻 [GitHub](https://github.com/stephtavzz)  


## 🏁 Conclusão

Este projeto representa um marco no aprendizado sobre integração entre .NET e Azure, mostrando como é possível levar uma API local para a nuvem com facilidade, incluindo banco de dados totalmente hospedado no Azure SQL Server.

Servirá de base para futuras atualizações, como:

- Autenticação JWT;
- Deploy contínuo via GitHub Actions;
- Monitoramento com Application Insights.

> ✨ “A tecnologia se torna poderosa quando compartilhada com propósito.” ✨


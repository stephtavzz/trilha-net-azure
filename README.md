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


---

## 🧠 Diagrama de Arquitetura (Exemplo)

```mermaid
graph TD
A[Cliente / Navegador] --> B[API - TrilhaNetAzureDesafio]
B --> C[Controllers]
C --> D[Camada de Domínio]
D --> E[Entity Framework Core]
E --> F[Banco de Dados SQL Server]
B --> G[Swagger UI]

````

> 💡 O diagrama acima representa o fluxo principal de requisições HTTP processadas pela API.

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
   - dotnet publish
   - Os arquivos foram gerados em:
     
     ````
     /bin/Release/net9.0/publish
     ````

2. Extensão usada:
  - Azure App Service para VS Code (Extensão oficial da Microsoft)

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

## 🧾 Exemplo de Resposta da API

````
{
  "message": "Bem-vindo(a) ao TrilhaNetAzureDesafio! Acesse a API em /swagger"
}
````

## 📚 Aprendizados do Projeto

- Entendimento sobre estruturas de Web API minimalistas
- Configuração e uso do Entity Framework Core
- Geração automática de documentação com Swagger
- Processo completo de deploy em nuvem com Azure
- Utilização do Visual Studio Code com Azure App Service

## 🧑‍💻 Autora

**Stephanie Tavares dos Santos**
🔗 [LinkedIn](https://www.linkedin.com/in/stephanie-t-santos/)  
💻 [GitHub](https://github.com/stephtavzz)  


## 🏁 Conclusão

Este projeto representa um marco no aprendizado sobre integração entre .NET e Azure, mostrando como é possível levar uma API local para a nuvem com facilidade e organização.
Servirá de base para futuras atualizações, como:

- Integração com banco de dados no Azure SQL;
- Autenticação JWT;
- Deploy contínuo via GitHub Actions.

> ✨ “A tecnologia se torna poderosa quando compartilhada com propósito.” ✨


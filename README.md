# Exemplo de projeto MVC de cadastro de usuários e cursos que consome dados da API

## 1. Introdução

O projeto foi criado com base no curso de *Configuração da arquitetura front-end com .NET Core* realizado no portal da DIO.

## 2.Propósito

Consumir dados da API utilizando a biblioteca Refit e estruturação das pastas em um projeto MVC

## 3.Ferramentas

 - .NET Core com C# com sdk .NET 6.0.100
 - Visual Studio 2022

## 4. Dependências

- Microsoft.VisualStudio.Web.CodeGeneration.Design v6.0.0 - Ferramenta de geração de código para ASP.NET Core. Contém o comando dotnet-aspnet-codegenerator usado para gerar controladores e visualizações.
- Refit v6.1.15 - A biblioteca REST de tipo seguro automático para Xamarin e .NET.
- Refit.HttpClientFactory v6.1.15 - Reinstale as extensões de fábrica do cliente HTTP.

## 5. Estrutura

 - Controllers - Utilizados para o tratamento das requisições Http.
 - Handlers - Utilizados interceptar as informações.
 - Models - Camada de modelos
    - Entities - Utilizadas para formatar as entidades
    - ViewModels - Utilizadas para formatar o recebimento e envio de parâmetros
 - Services - Camada de serviços
 - Views - Páginas html da aplicação.

# 6. Setup

- Clone o projeto
- Adicione as depedências
- Informe a connectionString do banco de dados no arquivo appsettings.json no formato a seguir: 
          
          `"UrlWebApplicationApi": "",`
          
O projeto estará pronto para inicialização

# 7. Informações Adicionais

- As interfaces são utilizadas para inverção de controle na aplicação e a injeção das dependências do Refit e do Handler BearerTokenMessageHandler é realizada no arquivo de setup, no caso o Program.cs
- O código a seguir deve ser inserido no arquivo de setup somente em ambiente de desenvolvimento e nunca em produção.

//Desabilita a verificação do certificado digital do lado do cliente (Não utilizar em ambiente de produção)

//Inicio

`var clientHandler = new HttpClientHandler
{
  ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; } 
};`

//Fim

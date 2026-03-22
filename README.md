# DevConnect Consulting

## Sobre o Projeto
Este projeto foi desenvolvido como parte do **Checkpoint 4 da disciplina de C# Development**, com o objetivo de criar uma aplicação web utilizando **ASP.NET Core MVC** que simula uma **consultoria em desenvolvimento de software**.

A aplicação permite que clientes solicitem serviços com base em problemas disponíveis, enquanto um **Tech Lead** gerencia essas solicitações, aprovando ou rejeitando e direcionando para desenvolvedores disponíveis.

---

## Integrantes
- Erick Molina – RM 553852  
- Felipe Castro Salazar – RM 553464  
- Marcelo Vieira de Melo – RM 552953  
- Rayara Amaro Figueiredo – RM 552635  
- Victor Rodrigues – RM 554158  

---

## Objetivo
Desenvolver uma aplicação web dinâmica que:
- Simule o funcionamento de uma consultoria de desenvolvimento
- Permita a interação entre cliente e equipe técnica
- Utilize boas práticas com ASP.NET Core MVC

---

## Tecnologias Utilizadas
- C#
- ASP.NET Core MVC
- Bootstrap
- JavaScript
- Razor

---

## Funcionalidades

### Cliente
- Visualização de serviços/problemas em formato de cards  
- Exibição de nome, descrição e tempo de resposta  
- Solicitação de serviço com envio de nome e e-mail  
- Alerta de confirmação ao realizar a solicitação  

---

### Tech Lead (Admin)
- Login com autenticação  
- Visualização das solicitações recebidas  
- Aprovação ou reprovação das solicitações  
- Encaminhamento para desenvolvedor disponível  

---

## Autenticação
O sistema utiliza autenticação baseada em:
- **Claims**
- **Cookies**

Além disso, o layout da aplicação realiza a verificação de login para controle de acesso às áreas restritas.

---

## Estrutura do Projeto
O projeto segue o padrão **MVC (Model-View-Controller)**:

- **Models:** representam os dados (problemas, solicitações, usuários)  
- **Views:** interface com o usuário  
- **Controllers:** controle das requisições e regras de negócio  
- **Services:** gerenciamento de dados em memória  

---

## Login de Teste
```
Usuário: techlead  
Senha: 123456  
```
---

## Como Executar o Projeto
```
1. Clone o repositório:
   git clone <url-do-repositorio>

2. Abra no Visual Studio  

3. Execute o projeto (Ctrl + F5)

4. Acesse no navegador:
   https://localhost:<porta>
```
---

## Considerações Finais

Este projeto permitiu aplicar na prática os conceitos de desenvolvimento web com ASP.NET Core MVC, incluindo estrutura em camadas, autenticação e construção de interfaces dinâmicas.

A solução desenvolvida simula de forma clara o fluxo de uma consultoria, desde a solicitação do cliente até a análise e decisão do Tech Lead, proporcionando uma experiência completa e funcional.

Além disso, o trabalho em equipe e o versionamento contribuíram para a organização do projeto e para a evolução das boas práticas de desenvolvimento.

# 📊 Sistema de Gestão Executiva & Relatórios (WPF / .NET)

Sistema desktop corporativo desenvolvido em C# e WPF para controle de cadastros, lançamentos de vendas e geração automatizada de relatórios em Excel estilizados.

---

## 🚀 Tecnologias Utilizadas

- **Linguagem:** C# (.NET)
- **Interface:** WPF (Windows Presentation Foundation)
- **Design System:** Material Design In XAML Toolkit
- **Arquitetura:** MVVM (Model-View-ViewModel) com `CommunityToolkit.Mvvm`
- **Banco de Dados:** SQLite com `Dapper` (Micro-ORM)
- **Exportação de Dados:** `ClosedXML`

---

## ✨ Principais Funcionalidades

- **Navegação Dinâmica (Single-Window):** Troca de visões fluida utilizando padrão MVVM desacoplado.
- **Gestão Financeira:** Registro e controle de vendas vinculadas a clientes e produtos.
- **Relatórios Corporativos:** Exportação automatizada para planilhas Excel com formatação monetária, cabeçalhos estilizados e linhas zebradas.
- **Interface Moderna:** Layout responsivo focado em usabilidade executiva.

---

## 📂 Estrutura do Projeto

```text
Projeto1-Excel/
│── Models/          # Entidades de dados (Cliente, Produto, Venda)
│── ViewModels/      # Lógica de apresentação e comandos (MVVM)
│── Views/           # Interfaces de usuário XAML (Cadastro, Financeiro, Relatórios)
│── Services/        # Serviços de Banco de Dados e manipulação de Excel
│── Repositories/    # Acesso e persistência de dados via Dapper

📋 App para Consultas

Este é um aplicativo desktop desenvolvido em C# utilizando Windows Forms na IDE Visual Studio. O objetivo principal é ajudar minha mãe, que trabalha com bordados, a organizar seus pedidos e criar um cronograma de entregas.

O sistema utiliza SQLite como banco de dados local, facilitando o armazenamento e consulta das informações de forma prática e eficiente.

🧵 Objetivo
Facilitar a gestão de encomendas e contatos de clientes para pequenos empreendedores, oferecendo um sistema simples e funcional para:

Cadastrar clientes

Visualizar pedidos

Consultar informações rapidamente

🖥️ Tecnologias Utilizadas
C#

Windows Forms (.NET)

SQLite (como banco de dados local)

Visual Studio

📌 Funcionalidades
TELA 1 – Início
Tela principal de navegação, com acesso a duas funcionalidades principais:

Cadastro de Clientes

Visualização de Clientes

TELA 2 – Cadastro de Clientes
Através do botão "Cadastrar Clientes", é possível registrar:

Nome

Número de celular

Quantidade de toalhas

Cores

Tipos de serviços executados

TELA 3 – Visualizar Clientes
Através do botão "Visualizar Clientes", você pode:

Pesquisar clientes pelo número de celular

Visualizar os dados previamente cadastrados

🗂️ Estrutura do Projeto

/AppParaConsultas
│
├── /bin
├── /obj
├── /Resources
├── Form1.cs         # Tela inicial
├── CadastroForm.cs  # Tela de cadastro
├── VisualizarForm.cs# Tela de visualização
├── database.sqlite  # Banco de dados local
└── README.md

✅ Requisitos para Execução
-> Visual Studio instalado

-> .NET Framework compatível com Windows Forms

💡 Considerações
Esse projeto foi feito com carinho como uma forma de retribuir o trabalho e dedicação da minha mãe. Sinta-se à vontade para usar, modificar ou sugerir melhorias!

📬 Contato
Se quiser entrar em contato comigo:

[Kami Vilela]

[/in/kamivilela]

OBS.:
-> Pacote do SQLite instalado (System.Data.SQLite)

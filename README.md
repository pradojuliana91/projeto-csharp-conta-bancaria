## 🏦 Sistema Bancário | Acelera Maker

Projeto desenvolvido em C# com .NET 8 utilizando uma aplicação Console para simular operações bancárias como criação de contas, depósitos, saques e transferências.

O sistema foi criado durante o programa Acelera Maker com foco na prática de conceitos de Programação Orientada a Objetos (POO), persistência de dados e organização em camadas. Além da proposta inicial, também foram implementadas melhorias como integração com MySQL, Docker, tratamento de exceções e testes unitários.

## 🚀 Funcionalidades

- 💳 Cadastro de contas correntes e poupança
- 🔍 Busca de contas por agência e número
- 📋 Listagem de contas cadastradas
- ✏️ Atualização de contas
- ❌ Remoção de contas
- 💰 Depósitos
- 💸 Saques
- 🔄 Transferências entre contas
- 🛡️ Validação de saldo e operações
- ⚠️ Tratamento personalizado de exceções
- 🗄️ Persistência de dados com MySQL
- 🎨 Menu interativo colorido
- 🧪 Testes unitários

## 🛠️ Tecnologias Utilizadas

- C#
- .NET 8
- MySQL
- ADO.NET
- Docker
- xUnit
- FluentAssertions
  
## 📦 Instalação

1. Clone o repositório

```bash
git clone https://github.com/pradojuliana91/projeto-csharp-conta-bancaria.git
```

2. Acesse a pasta do projeto

```bash
cd projeto-csharp-conta-bancaria
```

3. Execute o ambiente com Docker Compose

```bash
docker-compose up -d
```

O container MySQL será iniciado automaticamente junto com a criação do banco `contabancaria` e carga dos dados iniciais.


4. Execute a aplicação

```bash
dotnet run
```

## 🗄️ Banco de Dados

- Banco utilizado: `contabancaria`
- Tabela principal: `contas`

O sistema utiliza índice `UNIQUE` para evitar contas duplicadas com a mesma agência e número.

## 📁 Estrutura de Pastas

```txt
ContaBancaria
│
├── Controllers
├── Exceptions
├── Menu
├── Models
├── Repositories
├── Utils
└── Program.cs
```

## 🧪 Testes Unitários

Os testes unitários validam as principais regras de negócio da aplicação, incluindo:

- depósitos
- saques
- transferências
- validações
- saldo insuficiente
  
Execute os testes com:
```bash
dotnet test
```

## 📚 Conceitos Praticados

- Programação Orientada a Objetos
- Herança e Polimorfismo
- Encapsulamento
- Interfaces
- Repository Pattern
- Persistência de Dados
- Tratamento de Exceções
- Arquitetura em Camadas

## 🤝 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## 🧑‍💻 Autor

**Juliana do Prado Fernandes**  
Desenvolvedora participante do programa **Acelera Maker - Montreal**

[LinkedIn](https://www.linkedin.com/in/pradojuliana91/) • [GitHub](https://github.com/pradojuliana91)

## 📚 Licença

Este projeto está licenciado sob a licença MIT.

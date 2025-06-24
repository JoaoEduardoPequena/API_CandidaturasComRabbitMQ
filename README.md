# 📬 Sistema de Candidaturas com RabbitMQ, .NET e Envio de Ficha de confirmação por E-mail

Este projeto implementa um fluxo assíncrono para submissão e processamento de candidaturas, utilizando **ASP.NET Core 8**, **RabbitMQ**, **Clean Architecture** e **BackgroundService** para envio automático de e-mail com ficha de confirmação.

---

## 📌 Visão Geral

### Cenário

1. O candidato submete sua candidatura via API REST.
2. A API salva os dados no banco de dados.
3. A API publica a candidatura em uma fila do RabbitMQ.
4. Um serviço consumidor:
   - Processa os dados da fila,
   - Gera uma ficha de confirmação (PDF),
   - Envia a ficha por e-mail ao candidato.

---

## 🔄 Fluxo de Funcionamento

1. 🧑‍💼 Usuário envia uma candidatura via `POST /api/candidaturas`
2. 💾 API salva os dados no banco de dados
3. 📬 API publica a mensagem na fila RabbitMQ
4. 🧑‍🔧 Worker consome a mensagem da fila
5. 🧾 Worker gera a ficha de confirmação (PDF)
6. ✉️ Ficha é enviada por e-mail ao candidato

---

## ⚙️ Tecnologias Utilizadas

- ASP.NET Core 8
- Clean Architecture
- CQRS + MediatR
- SQL Server + Entity Framework Core 8
- Dapper
- RabbitMQ
- Report View
- BackgroundService

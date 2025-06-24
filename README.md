# 📬 Sistema de Candidaturas com RabbitMQ, .NET e Envio de Ficha por E-mail

Este projeto implementa um fluxo assíncrono para submissão e processamento de candidaturas, utilizando **ASP.NET Core 8**, **RabbitMQ**, **Clean Architecture** para envio automático de e-mail com ficha de confirmação.

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

```mermaid
graph TD
A[Usuário envia candidatura via POST] --> B[API salva no banco]
B --> C[API publica na fila RabbitMQ]
C --> D[Worker consome da fila]
D --> E[Gera ficha de confirmação]
E --> F[Envia e-mail com ficha em anexo]

---

## ⚙️ Tecnologias Utilizadas

- ASP.NET Core 8
- Clean Architecture
- CQRS + MediatR
- SQL Server + Entity Framework Core 8
- Dapper
- RabbitMQ
- Report View ( geração do relatório em PDF)
- BackgroundService

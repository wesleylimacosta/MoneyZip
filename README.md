# MoneyZip

MoneyZip é um projeto de uma plataforma de pagamentos desenvolvido com a aplicação de princípios avançados de engenharia de software, como **Domain-Driven Design (DDD)**, **SOLID** e **Clean Architecture**, garantindo um código robusto, escalável e de fácil manutenção.

## Aplicação

MoneyZip é uma plataforma de pagamentos projetada para facilitar depósitos e transferências de valores entre usuários. A aplicação suporta dois tipos de perfis:

- **Usuários comuns**: Podem enviar e receber dinheiro.
- **Lojistas**: Podem apenas receber transferências.

Ambos os tipos de perfil são equipados com carteiras virtuais para gerenciar saldos e realizar transações financeiras entre si.

## Objetivo

O objetivo principal do MoneyZip é proporcionar uma experiência **segura** e **eficiente** para depósito e transferência de dinheiro, atendendo às necessidades de usuários comuns e lojistas em um sistema integrado e confiável.

## Requisitos Funcionais

### Cadastro de Usuários

Para ambos os tipos de usuário (comuns e lojistas), são requeridos os seguintes dados:

- Nome completo
- CPF
- E-mail
- Senha

> **Nota**: CPF e e-mail devem ser únicos no sistema, evitando duplicidade de registros.

### Transferências

- **Usuários comuns**: Podem enviar dinheiro tanto para lojistas quanto para outros usuários comuns.
- **Lojistas**: Estão restritos a apenas receber transferências, sem a possibilidade de enviar valores.
- **Validação de Saldo**: Antes de processar qualquer transferência, o sistema verifica se o usuário remetente possui saldo suficiente.
- **Autorização Externa**: Todas as transferências exigem a consulta a um serviço autorizador externo. Para este projeto, foi utilizado o mock disponível em: [https://util.devi.tools/api/v2/authorize](https://util.devi.tools/api/v2/authorize).
- **Transacionalidade**: A operação de transferência é tratada como uma transação atômica, sendo revertida em caso de qualquer inconsistência, com o valor retornando integralmente à carteira do remetente.
- **Notificações**: Após o recebimento de um pagamento, o usuário ou lojista é notificado por meio de um serviço externo de envio de e-mails ou SMS. Este serviço, sujeito a eventuais instabilidades, foi simulado utilizando o mock: [https://util.devi.tools/api/v2/notify](https://util.devi.tools/api/v2/notify).

## Características Técnicas

O desenvolvimento do MoneyZip foi orientado por boas práticas de arquitetura e design de software, destacando-se:

- **DDD**: Modelagem baseada em domínios para refletir as regras de negócio de forma clara e coesa.
- **SOLID**: Princípios aplicados para garantir flexibilidade e robustez no código.
- **Clean Architecture**: Estrutura organizada em camadas para promover desacoplamento e testabilidade.

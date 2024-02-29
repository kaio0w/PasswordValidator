# PasswordValidator
Frattina Project

# Password Validator API

## Descrição

API simples para validar senhas de acordo com critérios específicos.

## Pré-requisitos

- [Dotnet SDK](https://dotnet.microsoft.com/download) instalado
- Postman ou qualquer ferramenta de teste de API

## Configuração

1. Clone o repositório:

```bash
git clone https://github.com/kaio0w/PasswordValidator.git


Endpoints
Validar Senha
URL: http://localhost:5002/Password/ValidatePassword

Método: POST

Corpo da Requisição:
{
    "password": "SuaSenhaAqui"
}

Resposta de Exemplo:
{
    "result": true
}


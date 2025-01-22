TaskManagerAPI - Português
Este projeto é uma API RESTful para gerenciamento de tarefas, projetos e usuários, com foco na organização e produtividade das equipes.

Visão Geral
O sistema visa facilitar a organização e o monitoramento das tarefas diárias de uma equipe. Ele permite criar projetos, adicionar e gerenciar tarefas, além de controlar o progresso dessas tarefas com funcionalidades de atualização e remoção.

Detalhes do Sistema
Usuário
O usuário é a pessoa que acessa e utiliza o sistema, possuindo uma conta com permissões para interagir com projetos e tarefas.

Projeto
Um projeto é uma unidade que contém várias tarefas. Usuários podem criar, visualizar e gerenciar projetos.

Tarefa
A tarefa é a unidade de trabalho dentro de um projeto, com título, descrição, data de vencimento e status (pendente, em andamento, concluída).

Funcionalidades da API
Listagem de Projetos

Método: GET
URL: /v1/Projects
Descrição: Recupera todos os projetos de um usuário.
Visualização de Tarefas

Método: GET
URL: /v1/Tasks
Descrição: Retorna todas as tarefas de um projeto específico.
Criação de Projetos

Método: POST
URL: /v1/Projects/Create
Corpo:
json
Copiar
Editar
{
    "name": "Novo Projeto",
    "description": "Descrição do projeto"
}
Criação de Tarefas

Método: POST
URL: /v1/Tasks/Create
Corpo:
json
Copiar
Editar
{
    "title": "Tarefa 1",
    "description": "Descrição da tarefa",
    "dueDate": "2025-01-30",
    "priority": "alta",
    "projectId": 1
}
Atualização de Tarefas

Método: PUT
URL: /v1/Tasks/Update
Corpo:
json
Copiar
Editar
{
    "taskId": 123,
    "status": "em andamento",
    "priority": "média"
}
Remoção de Tarefas

Método: DELETE
URL: /v1/Tasks/Delete
Corpo:
json
Copiar
Editar
{
    "taskId": 123
}
Regras de Negócio
Prioridades de Tarefas

Cada tarefa deve ter uma prioridade (baixa, média, alta).
A prioridade não pode ser alterada após a criação.
Restrições de Remoção de Projetos

Um projeto não pode ser removido enquanto houver tarefas pendentes.
Se um projeto contiver tarefas pendentes, a API retorna um erro indicando a necessidade de concluir ou remover as tarefas primeiro.
Histórico de Atualizações

Cada atualização em uma tarefa gera um histórico que inclui a modificação, a data e o usuário responsável.
Limite de Tarefas por Projeto

Cada projeto pode ter no máximo 20 tarefas. A tentativa de adicionar mais tarefas resulta em erro.
Relatórios de Desempenho

A API gera relatórios sobre o número médio de tarefas concluídas por usuário nos últimos 30 dias, acessíveis apenas por usuários com função "gerente".
Comentários nas Tarefas

Os usuários podem adicionar comentários às tarefas, e esses são registrados no histórico da tarefa.
Requisitos
Cobertura de Testes: Pelo menos 80% de cobertura de testes de unidade.
Banco de Dados: Utilize qualquer banco de dados para persistência de dados.
Docker: O projeto deve ser executado no Docker. Instruções de execução devem estar no README.md.
Como Usar
Criação de Usuário

Endpoint: /v1/Users/Create
Corpo:
json
Copiar
Editar
{
    "username": "usuario@empresa.com",
    "password": "senha",
    "role": "admin" // admin, gerente, usuário
}
Login

Endpoint: /v1/Authentication/Login
Corpo:
json
Copiar
Editar
{
    "username": "usuario@empresa.com",
    "password": "senha"
}
Criação de Projeto

Endpoint: /v1/Projects/Create
Corpo:
json
Copiar
Editar
{
    "name": "Novo Projeto",
    "description": "Descrição do projeto"
}
Criação de Tarefa

Endpoint: /v1/Tasks/Create
Corpo:
json
Copiar
Editar
{
    "title": "Tarefa 1",
    "description": "Descrição da tarefa",
    "dueDate": "2025-01-30",
    "priority": "alta",
    "projectId": 1
}
Atualização de Tarefa

Endpoint: /v1/Tasks/Update
Corpo:
json
Copiar
Editar
{
    "taskId": 123,
    "status": "em andamento"
}
Remoção de Tarefa

Endpoint: /v1/Tasks/Delete
Corpo:
json
Copiar
Editar
{
    "taskId": 123
}
Contribuições
William Borges

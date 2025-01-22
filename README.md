# TaskManagerAPI

Este projeto é uma API RESTful para gerenciamento de tarefas, projetos e usuários, com foco na organização e produtividade das equipes.

## Visão Geral
O sistema visa facilitar a organização e o monitoramento das tarefas diárias de uma equipe. Ele permite criar projetos, adicionar e gerenciar tarefas, além de controlar o progresso dessas tarefas com funcionalidades de atualização e remoção.

## Detalhes do Sistema

### Usuário
O usuário é a pessoa que acessa e utiliza o sistema, possuindo uma conta com permissões para interagir com projetos e tarefas.

### Projeto
Um projeto é uma unidade que contém várias tarefas. Usuários podem criar, visualizar e gerenciar projetos.

### Tarefa
A tarefa é a unidade de trabalho dentro de um projeto, com título, descrição, data de vencimento e status (pendente, em andamento, concluída).

## Funcionalidades da API

### Listagem de Projetos

**Método**: GET  
**URL**: /v1/Projects  
**Descrição**: Recupera todos os projetos de um usuário.

### Visualização de Tarefas

**Método**: GET  
**URL**: /v1/Tasks  
**Descrição**: Retorna todas as tarefas de um projeto específico.

### Criação de Projetos

**Método**: POST  
**URL**: /v1/Projects/Create  
**Corpo**:
```json
{
    "name": "Novo Projeto",
    "description": "Descrição do projeto"
}

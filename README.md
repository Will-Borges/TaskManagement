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

# Endpoints Projeto

**createProject** 
**Método**: POST  
**URL**: /v1/Project/create-project  
**Descrição**: Responsavel por criar o projeto.
```json
{
    "name": "Lima",
    "description": "Sistema robusto para gerenciar dados críticos, melhorar a eficiência e garantir segurança.",
    "userId": 1
}
```

**ListProjectsByUserId** 
**Método**: POST  
**URL**: /v1/Project/list-projects-userId?userId=1
**Descrição**: Responsavel por litar os projetos filtrando pelo id do usuário.




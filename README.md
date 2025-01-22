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

# Endpoints Entidade Projeto

### **CreateProject** 
Método: POST  
URL: /v1/Project/create-project  
Descrição: Responsavel por criar o projeto.
```json
{
    "name": "Lima",
    "description": "Sistema robusto para gerenciar dados críticos, melhorar a eficiência e garantir segurança.",
    "userId": 1
}
```

## Response
```json
{
    "projectId": 1,
    "projectUserId": 1,
    "projectSuccesfullyCreated": true
}
```
___

### **ListProjectsByUserId** 
Método: GET  
URL: /v1/Project/list-projects-userId?userId=1
Descrição: Responsavel por listar os projetos filtrando pelo id do usuário.

## Response
```json
{
   [
    {
        "id": 3,
        "name": "Lima",
        "description": "Sistema robusto para gerenciar dados críticos, melhorar a eficiência e garantir segurança.",
        "user": [
            {
                "name": "Leandro",
                "position": "Gerente"
            }
        ],
        "tasks": [
            {
                "id": 3,
                "title": "Tarefa2",
                "description": "Descricao tarefa2",
                "dueDate": "2025-02-20T14:34:39.357",
                "status": 1,
                "priority": 1
            }
        ]
    },
    {
        "id": 4,
        "name": "Lima",
        "description": "Sistema robusto para gerenciar dados críticos, melhorar a eficiência e garantir segurança.",
        "user": [
            {
                "name": "Leandro",
                "position": "Gerente"
            }
        ],
        "tasks": []
    }
]
}
```
___

### **DeleteProject** 
Método: DELETE  
URL: /v1/Project/remove-project?projectId=1
Descrição: Responsavel por deletar o projetos filtrando pelo id do projeto.

## Response
```json
{
    "succesfullyDelete": true
}
```

# Endpoints Entidade Task

### **CreateTask** 
Método: POST  
URL: /create-task
Descrição: Responsavel por criar uma tarefa.
```json
{
    "title": "Tarefa1",
    "description": "Descricao da tarefa",
    "dueDate": "2025-02-20T14:34:39.357Z",
    "status": 1,
    "priority": 1,
    "projectId": 1
}
```

## Response
```json
{
    "id": 1,
    "projectSuccesfullyCreated": true
}
```
___

### **UpdateTask** 
Método: PUT  
URL: /update-task
Descrição: Responsavel por atualizar uma tarefa, se baseando pelo id.
```json
{
    "id": 1,
    "title": "Tarefa da casa",
    "description": "Tarefa atualizada por jovana",
    "dueDate": "0001-01-01T00:00:00",
    "status": 3,
    "projectId": 2
}
```

## Response
```json
{
    "succesfullyCreated": true
}
```

___

### **ListTasksByProjectId** 
Método: GET  
URL: /seach-tasks-by-projectId?projectId=3
Descrição: Responsavel por listar todas as tarefas filtrando pelo project id.

## Response
```json
[
    {
        "id": 3,
        "title": "Tarefa2",
        "description": "Descricao tarefa2",
        "dueDate": "2025-02-20T14:34:39.357",
        "status": 1,
        "priority": 1
    }
]
```
___

### **DeleteTask** 
Método: DELETE  
URL: /remove-task?taskId=8
Descrição: Responsavel por deletar a tarefa filtrando pelo id.

## Response
```json
{
    "succesfullyRemove": true
}
```

# Endpoints Entidade TaskHistory

### **SearchAllTaskHistories** 
Método: GET  
URL: /seach-all-tasks-histories
Descrição: Responsavel por listar todo o histórico das alterações das tarefas.

## Response
```json
{
[
    {
        "id": 9,
        "taskId": 3,
        "fieldName": "Description",
        "oldValue": "Descricao tarefa 222",
        "newValue": "Descricao tarefa 888",
        "changedAt": "2025-01-22T18:27:48.44536",
        "changedBy": "1"
    },
    {
        "id": 10,
        "taskId": 3,
        "fieldName": "Title",
        "oldValue": "Tarefa atualizada6",
        "newValue": "Tarefa da casa",
        "changedAt": "2025-01-22T18:44:17.962548",
        "changedBy": "1"
    },
    {
        "id": 11,
        "taskId": 3,
        "fieldName": "Description",
        "oldValue": "Descricao tarefa 888",
        "newValue": "Tarefa atualizada por jovana",
        "changedAt": "2025-01-22T18:44:17.963062",
        "changedBy": "1"
    }
]
```

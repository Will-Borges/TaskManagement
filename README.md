# TaskManagerAPI
- Este projeto é uma API RESTful para gerenciamento de tarefas, projetos e usuários, com foco na organização e produtividade das equipes.

## Visão Geral
- O sistema visa facilitar a organização e o monitoramento das tarefas diárias de uma equipe. Ele permite criar projetos, adicionar e gerenciar tarefas, além de controlar o progresso dessas tarefas com funcionalidades de atualização e remoção.

<br>

## Detalhes do Sistema

### Usuário
- O usuário é a pessoa que acessa e utiliza o sistema, possuindo uma conta com permissões para interagir com projetos e tarefas.

### Projeto
- Um projeto é uma unidade que contém várias tarefas. Usuários podem criar, visualizar e gerenciar projetos.

### Tarefa
- A tarefa é a unidade de trabalho dentro de um projeto, com título, descrição, data de vencimento e status (pendente, em andamento, concluída).

### Historico de Tarefa
- O histórico de tarefas é a unidade responsável por armazenar toda e qualquer alteração realizada pelo usuário nas tarefas.

<br>
<br>

# Endpoints Entidade Projeto

### **CreateProject** 
- Método: POST  
- URL: /v1/Project/create-project  
- Descrição: Responsavel por criar o projeto.
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

<br>

### **ListProjectsByUserId** 
- Método: GET  
- URL: /v1/Project/list-projects-userId?userId=1
- Descrição: Responsavel por listar os projetos filtrando pelo id do usuário.

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

<br>

### **DeleteProject** 
- Método: DELETE  
- URL: /v1/Project/remove-project?projectId=1
- Descrição: Responsavel por deletar o projetos filtrando pelo id do projeto.

## Response
```json
{
    "succesfullyDelete": true
}
```
<br>
<br>

# Endpoints Entidade Task

### **CreateTask** 
- Método: POST  
- URL: /create-task
- Descrição: Responsavel por criar uma tarefa.
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

<br>

### **UpdateTask** 
- Método: PUT  
- URL: /update-task
- Descrição: Responsavel por atualizar uma tarefa, se baseando pelo id.

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
<br>

### **ListTasksByProjectId** 
- Método: GET  
- URL: /seach-tasks-by-projectId?projectId=3
- Descrição: Responsavel por listar todas as tarefas filtrando pelo project id.

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

<br>

### **DeleteTask** 
- Método: DELETE  
- URL: /remove-task?taskId=8
- Descrição: Responsavel por deletar a tarefa filtrando pelo id.

## Response
```json
{
    "succesfullyRemove": true
}
```

<br>
<br>

# Endpoints Entidade TaskHistory

### **SearchAllTaskHistories** 
- Método: GET  
- URL: /seach-all-tasks-histories
- Descrição: Responsavel por listar todo o histórico das alterações das tarefas.

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

<br>

# Como Usar

1. Suba os containers no docker
   - **1.1** Na raiz do projeto onde está localizado o arquivo ***Dockerfile***, abra o ***CMD*** e execute o comando ***docker compose build***
   - **1.2** Execute o comando ***docker compose up***

2. Execute os scripts das tabelas no container do docker via terminal
   - **2.1** Na raiz do projeto onde está localizado o arquivo ***Dockerfile***, abra o ***CMD*** e execute o comando ***docker exec -it eclipseworkstaskmanagement-postgres-1 psql -U postgres -d eclipseworks*** 
   - **2.2** Execute os scripts encontrados na pasta ***Scripts*** localizada na raiz (copiando e colando)  

3. Crie um projeto para gerenciar suas tarefas, vinculando o criador no userId - Endpoint CreateProject
4. Adicione as tarefas vinculando o id retornado na criação do projeto - Endpoint CreateTask
5. Após esses passos conseguimos utilizar todos os endpoints restantes no projeto para organizar nossas tarefas da equipe.

____
   
# Fase 2: Refinamento - Perguntas ao PO
- Quando criar um projeto, é obrigatorio vincular os usuarios em uma unica requisição?
- Os erros devem seguir algum padrão?
- Precisamos de algum tipo de log para registro/controle da API?
- Qual o prazo para entregar e qual são os endpoints que não podem faltar nesse prazo (senso de urgência)?
- Qual a expectativa sobre os limites de uso da API? Devemos priorizar performance em algum dos endpoints especifico?
- Qual a ideia geral do projeto? devemos realizar micro-serviços? Qual a intenção de crescimento desse projeto (qual o rumo tomaremos)?
- Quantas pessoas estão nessa equipe?
- Existe alguma arquitetura/modelo padrão para seguir?
- Quais pessoas consigo retirar duvidas tecnicas caso necessario?
____
   
# Fase 3: Final - Melhorias
- Adicionaria constantes para cargos dos funcionarios.
- Adicionaria um 'delete lógico' por 0 e 1, para preservar os dados.
- Adicionaria mais validações dos dados de entrada, dependendo de como o PO me respondesse sobre o tamanho da API e como iriamos seguir (entendo mais sobre a regra de negócio), poderia adicionar uma camada extra na arquitetura chamada ***Presenter***, para fazer essas validações.
- Adicionaria mais validações nas execuções de banco, para evitar erros bobos como retornar um null e querer seguir a aplicaçao/fluxo do sistema.
- Adicionaria migrations para que o banco seja mais facil de operar.
- Adicionaria dependendo de como o PO respondesse o Entity Framework.
- Refinaria o histórico, para conseguir registrar tambem a remoção das tarefas e um registro geral na entidade projeto.
- Analisaria com mais calma a arquitetura para concentrar mais as funções nos domains.
- ***OBS:*** O relatório de desempenho não foi implementado dentro do prazo, não por falta de conhecimento, mas devido a limitações de tempo. Embora eu tenha conhecimento da abordagem correta, em alguns pontos, como a conversão direta do comando para a entidade (que sei não ser a melhor prática), não consegui dedicar o tempo necessário para aprimorar esses detalhes, optando por soluções mais rápidas para cumprir o prazo. No entanto, acredito que é possível perceber meu conhecimento técnico no restante da implementação, e estou totalmente disponível para debater cada abordagem que adotei e os motivos que levaram às minhas escolhas.

<br>

## Contribuições

William Borges

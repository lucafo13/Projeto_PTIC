# Projeto_PTIC

# Sistema de gerenciamento de estoque de produtos compráveis
 
**Integrantes:** Davi Lucas Ferreira de Oliveira — João Carlos Surica Benedito.
 
---
 
## Objetivo
 
O sistema tem a finalidade de gerir o estoque de produtos cadastrado em um banco de dados, os produtos devem possuir caracteristicas como nome, preço, estoque e quantidade mínima de estoque, dessa forma, o sistema consegue checar o estoque e dizer apartir dos status se o estoque checado é "Alerta", "Ok" e "Crítico".
 
## Justificativa
 
O sistema se torna uma ferramenta eficiênte e necessária para gerenciar estoques desde que, com a alta quantidade de produtos que podem ser vendidos em uma instituição, controlar todas as vendas sem causar falhas e mal ocorridos no processo se torna uma tarefa árdua e complexa, logo, um sistema que consiga gerenciar os estoques apartir das quantias vendidas se torna extremamente importante para facilitar uma tarefa repetitiva e que torna o processo total das vendas improdutivo.
 
## Descrição de Funcionalidades
 
O sistema funcionara em C#, uma linguagem rígida que controla as tipagens de cada variável de maneira estrita e segura, evitando possiveis erros como um produto ser cadastrado com "Arroz" de preço e "R$ 67,00" de nome.
 
O processo de funcionamento do código funciona da seguinte forma:
 
É criada uma Interface C# chamada `IProduct`, está que é a responsável por conter todas as características que o produto deve ter, sendo elas:
 
- ID
- Nome
- Estoque
- Min
- Preco
- Status
Em seguida, criasse uma classe `Product` qual herda da interface `IProduct`, contendo métodos como:

 
- um *constructor* para definir caracteristicas de cada objeto;
- `Addestoque`, que recebe um valor inteiro para ser adicionado;
- `RemoveStoque`, para remover estoque de maneira segura o estoque atual do item, alertando o usuario se a retirada é ou não perigosa;
- `Check`, para checar os status do item, podendo ser crítico, alerta ou Ok;
- `CheckUp`, para mostrar as características do objeto;
- outros métodos para ver status.
Concomitantemente, existirá uma classe específica chamada `ProductController`, está que controla o fluxo de ações do código, contendo um método assincrono de cadastrar, onde é possível cadastrar ao produto no banco de dados Postgres SQL que guarda os produtos na tabela `produto`, também contemos o método `Inicio`, qual de fato controla o fluxo de ações do app, desde o controle de ações feitas no produto, como os próprios métodos definidos na classe `Product`.
 <img width="797" height="132" alt="image" src="https://github.com/user-attachments/assets/a679f5b1-5ab7-4f6f-9955-45a873c90ba7" />

## Fluxograma
 
Link dos fluxogramas: [Abrir no Google Drive](https://drive.google.com/file/d/1QYainqxIpzL3AftonQbXvIjeKuLGa8YT/view?usp=drive_link)

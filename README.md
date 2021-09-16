# Controle de lideres de ginasio Pokemon
Projeto realizado para o bootcamp Everis New Talents #2 .NET da Digital Innovation One em conjunto com a Everis e mentorado pelo profº Thiago Campos..

O projeto é uma API RESTful com o ASP.NET Core, utilizando o Entity Framework para a interação com o banco de dados SQL Server.

O projeto proposto era de criar um gerenciador de espaçonaves do Star Wars utilizando boas práticas de arquitetura back-end e SQL Server. 

Para distinguir do projeto original, e me desafiar ainda mais, criei um sistema de gerenciamento de líder de ginásio.

Foi feito um sincronizador para a alimentação do banco de dados, onde eu optei por consumir a API da [PokeAPI](https://pokeapi.co/api/v2/pokemon) para puxar os dados dos Pokemon e como não encontrei uma API com dados de Treinadores e Ginásios, criei um importador de dados em excel para fazer a alimentação de dados mais rapidamente.

Os dados de Pokemon como vêm direto da API, optei por serem somente métodos HttpGet, para não sobrescrevê-los. O mesmo não acontece com os treinadores e ginásios, que dei a liberdade de criar novos, capturar pokemons, liberta-los, entre outros.

Para mais informações, acesse meu [LinkedIn](https://www.linkedin.com/in/vinicius-nascimento-3682417b).

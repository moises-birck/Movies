Foi Criado um projeto divido em camadas. 

1ª- API.
	Conforme solicitado, foi montado uma camada de API para realizar o procedimento de verificar os prêmios de pior filme. 
	
	Ao startar a API, já irá chamar o código que busca o csv dentro da pasta do projeto, pasta "File/movielist.csv".
	Ao pegar o csv, já insere no banco e libera a API.
	
	Na API, há dois métodos, uma para consultar o Maior vencendor e o menor do prêmio e outro que trás todos os indicados salvos na base.	
	
	
2ª- Mesmo tendo na API, fiz um ConsoleApp, cujo o nome é "ReadMoviesCsv".
	É responsável por chamar, as camadas onde irá ler e posteriormente colocar na base de dados. Acontece ao executar o mesmo.
	Obs: Busca a pasta "File" e o arquivo movielist.csv, dentro dá camada do projeto citado.

	Criei ele, pois acho estranho criar no inicio dá aplicação de uma API.
	
3ª- Camada de infraestrutura,"InfraMovies"
	Onde será realizado as configs dos contextos e seus repositórios.
	
4ª- Dominio, "DomainMovies"
	Ficando com as entidades dá aplicação.

5ª- Aplicação, "ApplicationMovies"
	Camada onde ficará toda a parte de negócios 
	
6ª- Camada de testes de integração.
	Onde é feito testes de integrações dos filmes.
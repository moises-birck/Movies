Projeto de Verificação de Prêmios de Pior Filme
Este projeto é uma aplicação em .NET que realiza a verificação dos prêmios de pior filme. A aplicação foi dividida em camadas para melhor organização e separação de responsabilidades.

Estrutura do Projeto
O projeto é composto por várias camadas, cada uma com sua finalidade:

API: A camada de API é responsável por expor os serviços e endpoints necessários para consultar os prêmios de pior filme. Ao ser iniciada, a API automaticamente busca o arquivo CSV contendo a lista de filmes na pasta "File/movielist.csv" do projeto, insere os dados no banco de dados e libera a API para uso. A API possui dois métodos: um para consultar o maior e o menor vencedor de prêmios de pior filme, e outro para retornar todos os filmes indicados salvos no banco de dados.

ConsoleApp: Foi criado um aplicativo de console chamado "ReadMoviesCsv" que é responsável por ler o arquivo CSV e inserir os dados no banco de dados. Esse aplicativo é executado para realizar a carga inicial dos dados no momento da inicialização do projeto. Ele busca o arquivo "movielist.csv" na pasta "File" do projeto, tornando a carga de dados independente da API.

Infraestrutura (InfraMovies): Nessa camada são realizadas as configurações dos contextos e repositórios do banco de dados.

Domínio (DomainMovies): Nessa camada ficam as entidades do projeto, representando os objetos de domínio da aplicação.

Aplicação (ApplicationMovies): Essa camada é responsável por toda a lógica de negócio da aplicação, incluindo a verificação dos prêmios de pior filme e a interação com o banco de dados.

Testes de Integração: Essa camada contém os testes de integração do projeto, que são realizados para verificar a correta interação entre as diferentes camadas da aplicação.

Instruções de Instalação e Execução
Para instalar e executar o projeto, siga os passos abaixo:

Clone o repositório para sua máquina local.
Certifique-se de ter o .NET Framework instalado na sua máquina.
Abra o projeto no Visual Studio ou em outra IDE de sua preferência.
Compile e execute a solução.
A API estará disponível para uso nos endpoints definidos.
O aplicativo de console "ReadMoviesCsv" será executado automaticamente ao iniciar a aplicação, realizando a carga inicial dos dados.

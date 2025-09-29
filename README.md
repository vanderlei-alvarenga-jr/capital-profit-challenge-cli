### Repositório: capital-profit-challenge-cli

<p align="center">
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="30" width="50%" alt="csharp badge" /><img src="https://raw.githubusercontent.com/mayuki/Cocona/master/docs/assets/logo.svg" height="30" width="50%" alt="csharp badge" />
</p>

### Projeto: Code Challenge: Ganho de Capital
<p align="justify">
O objetivo deste exercício é implementar um programa de linha de comando (CLI) que calcula o imposto a ser pago sobre lucros ou prejuízos de operações no mercado financeiro de ações.
</p>

### Arquitetura do projeto:
A linguagem escolhida foi o C# por conta da minha desenvoltura com ela. A tecnologia escolhida foi o .Net 8, por ser uma tecnologia de mercado e mjuito disseminada atualmente. A estrutura do projeto é um monolito minimamente separado por camadas de comandos, modelos, exceções e a camada de negócio Processor.

### Frameworks e Bibliotecas:
Foi escolhido o framework CoconaLite para abstrair as implementações relativas ao suporte de comandos e seus parâmetros através do console.

Ref: [CoconaLite](https://www.nuget.org/packages/Cocona.Lite)

### Como abrir e compilar o projeto:
1. Clonar o projeto ou baixar os fontes;
2. Verificar e caso não estejam instaladas, baixar e instalar o SDK .Net 8 a IDE Visual Studio Code;
3. Instalar as extensões ".Net Dev Kit" e ".Net Extension Pack" dentro do IDE Visual Studio Code;
4. Abrir o console da IDE, entrar na pasta do projeto (./capital-profit-challenge-cli/capital-profit-challenge-cli)
5. Digitar o comando "dotnet build" para compilar os arquivos do projeto;

### Como executar o projeto:
Executados os passos de 1 a 4 dos passos de "Como abrir e compilar o projeto:":
1. Digitar o comando "dotnet run -- process --file-path .\files-to-process\first-example.json" no console para executar o projeto, onde "-- process" é o comando de processar o arquivo e "--file-path caminho/do/arquivo" é o parâmetro com o camiinho absoluto do arquivo ou o caminho relativo a partir da pasta do projeto aberta no console.
2. Para conferir se o arquivo foi processado, basta verificar se um arquivo com o sufixo "_result" foi gerado na mesma pasta de onde o arquivo de origem foi carregado.

### Como executar o projeto em modo de depuração:
Executados os passos de 1 a 4 dos passos de "Como abrir e compilar o projeto:":
1. Adicionar os pontos de parada (breakpoints) onde é desejado que o processo de execução seja pausado;
2. Foi criado um perfil de execução, no arquivo ".vscode/launch.json", chamado "Debug Me (capital-profit-challenge-cli)" para a depuração do projeto. Com ele, é possível abrir a aba "Run and Debug", selecionar o perfil "Debug Me" no topo e executar o modo debug.

### Como executar os testes unitários do projeto:
Executados os passos de 1 a 3 dos passos de "Como abrir e compilar o projeto:":
1. Abrir o console da IDE, entrar na pasta do projeto de testes unitários (./capital-profit-challenge-cli/capital-profit-challenge-cli-tests)
2. Digitar o comando "dotnet test" no console, onde todos os testes unitários serão executados e os mesmos serão listados na extens.
3. Será exibido um relatório dos testes executados no console. Também é possível verificar os testes na aba "Testing", exibida no menu lateral esquerdo da IDE, criada ao instalar as extensões.

### Sobre mim:

<p align="justify">
Gosto de dizer que sou um eterno aprendiz que, de vez enquando, aprecia estar na posição de mentor/instrutor.
<br clear="both">
Sou formado em Sistemas de Informação, mas sempre aprendo algo novo, principalmente sobre tecnologia, todos os dias.
<br clear="both">
Na sede por conhecimento, completei duas pós-graduações e sigo com desejo de mais, tentando ser um profissional e um parceiro de trabalho melhor a cada dia.
<br clear="both">
Gosto de contribuir nos projetos no que me é possível, tanto colocando a mão no código, quanto discutindo sobre decisões arquiteturais ou de organização. Sempre gostei de dividir meu conhecimento com aqueles que estão à minha volta.
<br clear="both">
Neste momento da minha vida profissional, atingi o nível de Desenvolvedor Sênior utilizando a tecnologia Microsoft .Net Core e seu ecossistema. Então, buscando reciclar meus conhecimento, voltei a estudar a tecnologia Java. Como já trabalhei com a linguagem no passado, meu foco é entender quais as metodologias e as ferramentas em alta do mercado. Desta forma o próximo passo é começar a atuar em uma nova posição utilizando essa tecnologia. Estes são os porquês da minha participação neste bootcamp.
</p>

### Meus Contatos:

[![LinkedIn](https://img.shields.io/badge/-LinkedIn-000?style=for-the-badge&logo=linkedin&logoColor=30A3DC&color:FFF)](https://www.linkedin.com/in/vanderlei-b-alvarenga-jr/)
[![GitHub](https://img.shields.io/badge/-GitHub-000?style=for-the-badge&logo=github&logoColor=30A3DC)](https://github.com/vanderlei-alvarenga-jr/)
[![Gmail](https://img.shields.io/badge/-Gmail-000?style=for-the-badge&logo=gmail&logoColor=30A3DC)](mailto:vanderlei.alvarenga.jr@gmail.com)

### Experiências no mundo de tecnologia:

<h3 align="left">Linguagens:</h3>
<br clear="both">

<div align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/java/java-original-wordmark.svg" height="60" alt="java badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="60" alt="csharp badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/css3/css3-original-wordmark.svg" height="60" alt="css badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/html5/html5-original-wordmark.svg" height="60" alt="html badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/javascript/javascript-original.svg" height="60" alt="javascript badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/php/php-original.svg" height="60" alt="php badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/typescript/typescript-original.svg" height="60" alt="typescript badge"  />
</div>

<h3 align="left">Ferramentas e Frameworks:</h3>
<br clear="both">

<div align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/azure/azure-original-wordmark.svg" height="70" alt="azure badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/azuredevops/azuredevops-original.svg" height="70" alt="azure devops badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/angular/angular-original.svg" height="60" alt="angular badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/bootstrap/bootstrap-original-wordmark.svg" height="60" alt="bootstrap badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-plain-wordmark.svg" height="70" alt="dot net badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" height="70" alt="dot net core badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/git/git-original-wordmark.svg" height="70" alt="git badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/jquery/jquery-original-wordmark.svg" height="70" alt="jquery badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/kibana/kibana-original-wordmark.svg" height="70" alt="kibana badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-original-wordmark.svg" height="70" alt="microsoft sql server badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/mysql/mysql-original-wordmark.svg" height="70" alt="mysql badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/rabbitmq/rabbitmq-original-wordmark.svg" height="70" alt="rabbitmq badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/swagger/swagger-original-wordmark.svg" height="70" alt="swagger badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/vscode/vscode-original-wordmark.svg" height="70" alt="vscode badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/vuejs/vuejs-original-wordmark.svg" height="70" alt="vuejs badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/wordpress/wordpress-original.svg" height="70" alt="wordpress badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/zend/zend-original-wordmark.svg" height="70" alt="zend framework badge"  />
</div>

### Aprimorando o conhecimento em:

<div align="left">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/amazonwebservices/amazonwebservices-original-wordmark.svg" height="70" alt="amazonwebservices logo"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/docker/docker-original-wordmark.svg" height="70" alt="docker badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/maven/maven-original-wordmark.svg" height="70" alt="maven badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/mongodb/mongodb-original-wordmark.svg" height="70" alt="mongodb badge"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/spring/spring-original-wordmark.svg" height="70" alt="spring badge"  />
</div>
# GranitoTest Solution
Solução que possui todos os recursos necessários para o funcionamento do projeto do enunciado enviado por e-mail.

## Palavras chaves do código interno
- Tax = Juros
- Calc = Cálculo
- Test
  Foi utilizado em dois contextos: 
  - como "prova"/"teste"("GranitoTest" -> "Teste da Granito").
  - em várias classes e métodos do projeto de testes("GranitoTest.Tests"), essas formam o teste unitário e o teste de integração.

## Etapas de Desenvolvimento
1. Definindo o escopo do projeto com base no enunciado informado por e-mail. <br /><br />
2. Inicialização do projeto - serão três camadas(projects da solução GranitoTest.sln): 
  - GranitoTest.Application: vai conter serviços e classes em comum da API. A intenção inicial era estruturar em Clean API, mas o projeto não contém camadas de infraestrutura/domínio então o resultado foi um pouco diferente de uma Clean comum.
  - GranitoTest.CalcApi: api que vai conter o endpoint de cálculo de juros compostos e o endpoint de URI do projeto no github.
  - GranitoTest.TaxApi: api que vai conter o endpoint que retorna a taxa de juros. <br /><br />
3. Implementação dos serviços e controladores(endpoints) descritos no item 2:
  - GranitoTest.Application.Services
    - TaxApiService: possui um método que consome o endpoint da TaxApi para coletar esse valor de taxa de juros(0.01) - esse Service é chamado pela CalcApi.
    - TaxCalcService: possui os dois métodos referentes às funcionalidades da CalcApi.
      Obs: considerando o conceito de Single Resposibility do SOLID e para melhor separação das funcionalidades desse serviço, o mesmo poderia ser dividido em dois, um para calcular juros compostos e outro para coletar o URI do github. Mas, decidi não optar por fazer isso, para ficar mais simples(dessa forma, fica um serviço para cada API).
  - GranitoTest.CalcApi:
    - /api/showmethecode -> Mostra o URI do github desse projeto.
    - /api/calculajuros?valorinicial=(valor1)&meses=(valor2) -> Calcula valor de juros compostos com base em um valor inicial e em meses(tempo).
  - GranitoTest.TaxApi:
    - /api/Tax -> Retorna a taxa de juros que vai ser utilizado na fórmula de juros compostos. <br /><br />
4. Criação do projetos de testes("GranitoTest.Tests"):
  - CalcControllerIntegrationTest: herda de IntegrationTest(por causa do WebHostBuilder) e testa a integração dos itens abaixo:
    - GranitoTest.Application.Services.TaxCalcService
    - GranitoTest.CalcApi.CalcController
  - TaxCalcServiceUnitTest: testa unitariamente a regra de negócio(cálculo de juros compostos) do serviço de cálculo. <br /><br />
5. Implementação de Docker e Docker Compose
  Para cada API foi criado um Dockerfile e depois foi criado o projeto do Compose.
  Fontes de pesquisa:
  - https://docs.docker.com/get-started/overview/
  - https://docs.docker.com/samples/aspnet-mssql-compose/
  - https://learn.microsoft.com/pt-br/dotnet/core/docker/build-container?tabs=windows
  - https://stackoverflow.com/questions/65673220/how-to-call-an-asp-net-core-web-api-endpoint-from-within-separate-docker-contain <br /><br />
  
## Observações
- FakeApi foi utilizada para mockar o serviço TaxApiService no teste de integração("CalcControllerIntegrationTest").
- Por falta de conhecimento prático de Docker anterior a esse projeto, essa foi a parte mais díficil de entender/implementar, mas por fim funcionou bem. As principais fontes utilizadas foram citadas no tópico 5 da seção anterior.
- Decidi fazer uma classe de padrão de retorno para a API de cálculo em um endpoint específico, apenas para demonstração(foi implementado e testado de última hora e por isso não repliquei para os outros endpoints).

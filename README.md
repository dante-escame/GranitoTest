# GranitoTest Solution

---

## Explicando algumas palavras chaves do código interno
### Tax
Juros
### Calc 
Cálculo
### Test
Foi utilizado em dois contextos: 
1. como prova/teste de aprendizagem("GranitoTest" -> "Teste da Granito").
2. em várias classes e métodos do projeto de testes("GranitoTest.Tests") que contém o teste unitário e o teste de integração.

---

## Etapa de Desenvolvimento
1. Definindo escopo do projeto com base no enunciado informado por e-mail.
2. Inicialização do projeto e definindo o escopo - serão três camadas(projects da solução GranitoTest.sln): 
  - GranitoTest.Application: vai conter serviços e classes em comum.
  - GranitoTest.CalcApi: api que vai conter o endpoint de cálculo de juros compostos e o endpoint de URI do projeto no github.
  - GranitoTest.TaxApi: api que vai conter o endpoint que retorna a taxa de juros.
3. Implementação dos serviços e controladores(endpoints) descritos no item 3:
  - GranitoTest.Application.Services
    - TaxApiService: hit no endpoint da TaxApi para coletar esse valor de taxa de juros(0.01).
    - TaxCalcService: possui os dois métodos referentes às funcionalidades da CalcApi.
    Obs: considerando o conceito de Single Resposibility do SOLID e para melhor separação das funcionalidades desse serviço, o mesmo poderia ser dividido em dois, um para calcular juros compostos e outro para coletar o URI do github.
    Mas, decidi não optar por fazer isso, para ficar mais simples(um serviço para cada API).
  - GranitoTest.CalcApi:
    - /api/showmethecode
    - /api/calculajuros?valorinicial=(valor1)&meses=(valor2)
   - GranitoTest.TaxApi:
    - /api/Tax
4. Criação do projetos de testes(GranitoTest.Tests):
  - CalcControllerIntegrationTest: herda de IntegrationTest(por causa do WebHostBuilder) e testa a integração dos itens abaixo:
    - GranitoTest.Application.Services.TaxCalcService
    - GranitoTest.CalcApi.CalcController
  - TaxCalcServiceUnitTest: testa unitariamente a regra de negócio(cálculo de juros compostos) do serviço de cálculo.
5. Implementação de Docker e Docker Compose

---

## Observações

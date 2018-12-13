
# Teste Finch - backend
Aplicação ASP.NET relativa ao backend do teste para a vaga de *Desenvolvedor/Analista*, na empresa Finch.

A aplicação oferece uma API REST para inclusão, consulta e alteração de protestos de títulos de pagamento, além da autenticação relacionada.

## Características
 - Linguagen: C# 5.0 (.NET 4.5);
 - Dependências:
	- ServiceStack: 5.0.0.0
	- ServiceStack.OrmLite.SqlServer: 5.0.0.0

Pressupõe a existência de banco de dados SQL Server para a aplicação. O endereço e o nome do banco são definidos nas chaves *DatabaseAddress* e *DatabaseName* no arquivo *Web.config*. 

Cria as tabelas no banco automaticamente, a partir de POCOs.

Projeto criado usando ServiceStack e o modelo que o framework propõe, para maior rapidez de desenvolvimento e manutenibilidade.

Inclui plugin de autenticação para fornecer estes recursos *out-of-the-box*.

API REST é acessada por meio de rotas claras e amigáveis.

## Composição principal
### Namespace FinchBackend.ServiceModel
Contém as classes básicas da aplicação representando DTOs de requisições e entidades (que, mais tarde, são usadas como representações das tabelas do banco de dados).

DTOs de requisição e resposta:
- `BaseRequest`: representa a estrutura mais básica de uma requisição. Contém propriedade relativa ao id da sessão, que é usado para autenticação.
- `GetProtest`: requisição para adquirir um protesto específico do banco
- `GetProtestResponse`: resposta a requisição `GetProtest`, com o protesto referido.
- `ProtestFileUpload`: requisição para upload de novos protestos, com seus bancos e devedores.
- `SearchProtests`: requisição para busca de protestos, com todos os filtros.
- `SearchProtestsResponse`: resposta para a requisição `SearchProtests`, com os protestos encontrados.
- `UpdateProtest`: requisição para atualização de protesto e seu título de pagamento e devedor.
- `UpdatePayment`: requisição para atualização de título de pagamento (não usado).
- `UpdateDebtor`: requisição para atualização de devedor (não usado).

DTOs de entidades:
- `BaseEntity`: representa a estrutura mais básica de uma entidade. Contém dados comuns a todas.
- `Debtor`: entidade de um devedor.
- `Payment`: entidade de um título de pagamento, com seu devedor.
- `PaymentProtest`: entidade de um protesto, com seu título de pagamento.
- `Protesto`: DTO com os campos dos arquivos CSV de protestos. Usada para, mais tarde, converter o protesto para a estrutura interna.

### Namespace FinchBackend.ServiceInterface
Contém as implementações dos web services que recebem os DTOs de requisição e trabalham com os DTOs de entidades. Em cada uma, os nomes dos métodos específica qual o verbo HTTP do serviço e o argumento, o formato dos dados da requisição.

Classes:
 - `SearchServices`: serviços de busca de protestos e aquisição de protesto específico.
 - `UpdateServices`: serviços de atualização de protestos, títulos de pagamento e devedores.
 - `UploadServices`: serviço de upload de protestos, títulos de pagamento e devedores.

### TODO

 - Testes;
 - Aprimoramento dos filtros da busca (a princípio, seria interessante usar uns atributos para indicar quais campos da request são filtros e implementar os filtros por meio de delegates associados a estes atributos; o escopo limitado do projeto e o tempo disponível inviabilizam isso).
 - Mais filtros na busca.
 - Personalização da autenticação, para mandar o id da sessão em cabeçalho.

-- Luiz Soares dos Santos Baglie (luizssb.biz *at* gmail *dot* com)

SOLUÇÃO: 
	Desenvolvido em 5 Camadas:
		Application: Definição e Implementação da Api 
		Service: Definição e Implementação das Regras de Negócio
		Data: Definição e Implementação do acesso ao Banco de Dados e persistência dos dados
		Domain: Definição e Implementação das Entidades do Negócio
		CrossCutting: Configurações gerais relacionadas a Injeção de Dependência e Mapeamento
	O Que você pode fazer na API?
		Inserir cursos e Pesquisar
		Increver-se em Cursos
		Pesquisar Estasticas do cursos (Estatiscas sao atualizadas caso X minutos ja tenha passado da ultima atualização)

TESTE
	Desenvolvido 4 Camadas par testes unitários utilizando XUnit e Moq:
		Application.Test: Definição e Implementação dos testes relacionado a api
		Service.Test: Definição e Implementação dos testes relacionado as regras de negócio
		Data.Test: Definição e Implementação dos testes relacionado a persistência dos dados
		Integration.Test: Definição e Implementação dos testes relacionado a integração do sistema como um todo

FERRAMENTAS:
	AspNetCore, EntityFramework, MySql, AutoMapper

MELHORIAS:
	Regras de Negócio mais elaboradas
	Mais propriedades para as Entidades de Dominio
	Consultas mais personalizadas
	Definição e Implementação conceitos HATEOAS para  se tornar um API REST FULL
	Implementação de mais testes unitários
	
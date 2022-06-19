# Teste Técnico Desenvolvedor II .NET
Construção de API para gerenciamentos de TODO's <br>

## Sobre 
A aplicação foi desenvolvida pensando em sua possivel extensão para mais funcionalidades e models/controladores além do Todo. <br>
Os pacotes utilizados ajudam na implementação de padrões de projetos utilizados 
como criação e mapeamento de novos objetos, responsabilidades únicas de classe, 
reutilização de código e isolamento de funcionalidades.
Além de padronizações de código para melhor leitura.

## Tecnologias Utilizadas: 
 - Banco de dados SqlServer
 - IDE Visual Studio Community 2022
 - .NET CORE 5

### Bibliotecas, Pacotes e Frameworks utilizados:
 - EntityFrameWorkCore
 - AutoMapper DependecyInjection
 - Provider SqlServer
 - EFCore Proxies Lazy-loading
 - EFCore Tools

## Rodando a aplicação
 - A aplicação utiliza a ConnectionString setada no arquivo appsettings.json. Altere o arquivo com configurações da sua maquina local.
 - Utilize o console de gerenciador de pacotes do NuGet e rode os comando de migrations: 
	- Add-Migration "migration"
	- Update-Database

### Possivels alterações necessárias
A aplicação está rodando na porta padrão disponibilizada pela plataforma. Portas 5001 para https e 5000 para http.
Se necessário alterar uma ou outra, basta alterar na linha 25 do arquivo launchSttings.json dentro da pasta Properties.
A abertura do navegador pata testes no swagger foi desabilitada. Caso seja necessário usa-lo,
será preciso alterar as linhas 22 e 23 do arquivo launchSttings.json dentro da pasta Properties.

A Api está padronizada para receber requisições de post e put
somente através do [FromBody] ou seja o corpo vem somente pelo formato JSON.
para aceitar requisições através de forms, será necessário alterar a assinatura dos mestodos para [FromForm]


## Credits
- [Rodolfo J.Silva](https://github.com/lrodolfol) (Developer)
- [LinkeIn](https://www.linkedin.com/in/rodolfoj-silva/)
- [Email](rodolfo0ti@gmail.com)

## License
The MIT License (MIT).

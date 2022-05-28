## 💻 Clean Architecture (Arquitetura Limpa)

Nessa arquitetura a regra de dependência aplicada consiste em que as camadas internas não devem ter qualquer dependência das externas e nem indiretas (termos, funções ou nomes de variáveis).
Ela possui características de testável, independência de Frameworks, Camada de apresentação e DB.

<img src="https://miro.medium.com/max/800/1*0R0r00uF1RyRFxkxo3HVDg.png" height="350" width="600"/>

**Divisão das responsabilidades por projeto:** </br>
✅ Domain: Modelo de domínio, Interfaces (repositories), Regras de Negócio. </br>
✅ Application: DTOs, Regras da aplicação (Services), Mapeamentos e Interfaces (services). </br>
✅ Infrastructure: Contexto DB, ORM, Lógica de acesso a dados (Repositories). </br>
✅ API: Interface Web (Endpoints, Controlladores) </br>


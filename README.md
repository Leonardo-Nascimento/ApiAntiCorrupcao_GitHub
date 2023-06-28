# ApiAntiCorrupcao_GitHub
Api feita para se entegrar a Api do GitHub para exportar suas funcionalidades.

## Configurações para utilizar a Api
-Você ter ter um **token acess** da sua conta do GitHub. Caso não saiba como gerar um token, siga as instruções do link a baixo:
- [Gerar um token acess](https://docs.github.com/pt/github-ae@latest/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens)

-Para Poder usar os recursos de **WebHook** é nescessário o link de algum serviço de webhook válido. No **site abaixo** você encontra um serviço de webhook gratuito temporario que servirá para testar os recursos que
você habilitar em seu repositório como por exemplo: commits, pull request, push e etc...
- [typedwebhook.tools](https://typedwebhook.tools/)

Caso você queira gerar outro **link de webhook** basta **atualizar a página**

## Observação:
-Não foi possível criar a funcionalidade de **atualizar o webhook**, pois não foi possivel acessar o **end point da Api do GitHub** pelo PostMan nem via request usando a biblioteca Octokit!


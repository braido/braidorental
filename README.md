# BraidoRental -  [DEMO](http://ec2-18-219-224-6.us-east-2.compute.amazonaws.com:3000/)

Para realizar o deploy, basta ter docker instaldo em sua máquina.

Execute o comando a seguir com o cmd na pasta src do Projeto:

```bash
docker stack deploy --compose-file docker-compose-deploy.yml braidorental
```

ou

```bash
docker-compose -f docker-compose-deploy.yml -p braidorental --no-ansi up -d --no-build
```

-------------------------------------
URL de acesso ao front-end: http://localhost:3000/

URL de acesso ao back-end: https://localhost:32743/

-------------------------------------

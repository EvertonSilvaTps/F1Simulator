# 🏎️ Competition Service

## Visão Geral

**Responsabilidades:** Gerenciar **Temporadas (Seasons)**, **Calendários (Races)**, **Circuitos (Circuits)** e as **Tabelas de Classificaçãos (Driver Standing e Team Standing)**.

O serviço atua como o **orquestrador temporal da temporada**, garantindo a integridade do campeonato e a execução correta das corridas.

## 1. Fluxos e resposabilidades

### 1.1. Circuit

Responsável por gerenciar e armazenar os **circuitos oficiais** da temporada.

O serviço é a **fonte da verdade** para circuitos e impõe regras de negócio rígidas

### 1.2. Competition

Responsável por inicializar e controlar o ciclo de vida de uma temporada, garantindo:

- Quantidade correta de circuitos  
- Integridade de equipes e pilotos  
- Ordem cronológica das corridas 

Também é Responsável por controlar a **máquina de estados** das corridas, assegurando:

- Sequencialidade  
- Exclusividade de execução  
- Imutabilidade de corridas finalizadas  

## 2. Fluxos de Negócio e Validações

### 2.1. Gerenciamento de Circuitos (CRUD)

#### 2.1.1. Modelo de Circuito

| Campo       | Tipo    | Obrigatório | Descrição |
|------------|---------|-------------|----------|
| id         | GUID    | Sim         | Identificador único |
| name       | String  | Sim         | Nome oficial do circuito |
| country    | String  | Sim         | País do circuito |
| lapsNumber | Integer | Sim         | Número total de voltas |
| isActive   | Boolean | Sim         | Indica se o circuito está ativo |

**Regra de criação**  
Ao cadastrar um circuito, o sistema define automaticamente:
- isActive = true

#### 2.1.2. Regra de Negócio
**Regras Globais**

- O sistema **permite no máximo 24 circuitos cadastrados**.  
- Qualquer tentativa de exceder esse limite é rejeitada
- Não é permitido cadastro, atualização ou delete de um circuito quando a temporada já está em andamento

**Resultado**

- ❌ Falha → violação de regra de negócio (limite máximo atingido)
- ❌ Falha → regra de negócio (temporada em andamento)   
- ✅ Sucesso → Circuito persistido e ativo  

#### 2.1.3. Validações Aplicadas

No cadastro e atualização de circuitos:

1. `name`, `country` e `lapsNumber` são obrigatórios  
2. `lapsNumber > 0`  
3. Não é permitido nome duplicado  
4. Limite máximo global: **24 circuitos**  

---

### 2.2. Gerenciamento da Competição

O gerenciamento da competição é responsável por controlar **todo o ciclo de vida de uma temporada**, desde sua criação até o encerramento oficial, garantindo a integridade
 das regras esportivas e do estado do campeonato.

#### 2.2.1. Criação de Temporada

O sistema permite a criação de **uma nova temporada por vez**, controlando automaticamente o ano de referência.

**Regras de Negócio**

- A **primeira temporada simulada** sempre inicia no ano **2025**.
- Cada nova temporada criada deve possuir o **ano sequencial** à última temporada registrada.
  - Exemplo: 2025 → 2026 → 2027.
- Não é permitido criar uma nova temporada se já existir uma temporada **ativa**.

**Comportamento do Sistema**

- Define o status inicial da temporada `IsActive is true`.
- Gera automaticamente o calendário com **24 corridas**.
- Inicializa as tabelas de:
  - `DriverStandings`
  - `TeamStandings`
- Todos os pilotos e equipes iniciam com **0 pontos**.

#### 2.2.2. Início de Corrida

O sistema permite iniciar uma corrida respeitando uma **máquina de estados rigorosa**.

**Regras de Negócio**

- **Sequencialidade**
  - Uma corrida só pode ser iniciada se a corrida anterior estiver com status `Finished`.
- **Concorrência**
  - Apenas **uma corrida** pode estar com status `InProgress` por vez.
- **Imutabilidade**
  - Uma corrida com status `Finished` **não pode ser reiniciada**.

**Comportamento do Sistema**

- Atualiza o status da corrida para `InProgress`.
- Bloqueia o início de qualquer outra corrida até sua finalização.


#### 2.2.3. Finalização de Corrida

A finalização de uma corrida ocorre de forma **assíncrona**, a partir do consumo de eventos.

**Fonte do Resultado**

- O resultado oficial da corrida é recebido via **fila (RabbitMQ)**.

**Regras de Negócio**

- Apenas corridas com status `InProgress` podem ser finalizadas.
- O resultado deve conter:
  - `driverId`
  - `driverName`
  - `teamId`
  - `teamName`
  - `Pontuatio`

**Comportamento do Sistema**

- Atualiza o status da corrida para `Finished`.
- Aplica a **pontuação oficial da Fórmula 1**.
- Atualiza:
  - `DriverStandings`
  - `TeamStandings`


#### 2.2.4. Finalização de Temporada

O sistema permite finalizar uma temporada apenas quando todo o calendário estiver concluído.

**Regra de Negócio Obrigatória**

- Uma temporada **só pode ser finalizada** se **todas as corridas** do calendário estiverem com status `Finished`.

**Comportamento do Sistema**

- Atualiza o status da temporada para `IsActive is false`.
- Impede qualquer nova modificação em:
  - Corridas
  - Classificações
- Libera o sistema para criação da **próxima temporada**.

#### 2.4.5. Estados da Temporada

| Status           |           Descrição            |
|------------------|--------------------------------|
| IsActive is true | Temporada em andamento         |
| IsActive is false| Temporada encerrada e imutável |


## 3. Contratos de API (Endpoints)

### 3.1 Circuit

| Verbo | Rota                                   | Descrição                                                        | Integração Necessária                   |
| ----- | -------------------------------------- | ---------------------------------------------------------------- | --------------------------------------- |
| POST  | `/api/circuit/create`                  | Cria um circuito, gerenciando nomes duplicados e quantidade      | Nenhuma                                 |
| POST  | `/api/circuit/create/circuits`         | Cria circuitos a partir de uma lista, validando nome e quantidade| Nenhuma                                 |
| GET   | `/api/circuit`                         | Retorna todos os circuitos cadastrados                           | Nenhuma                                 |
| GET   | `/api/circuit/{id}`                    | Retorna um circuito específico, a partir do seu id               | Nenhuma                                 |
| DELETE| `/api/circuit/{id}`                    | Deleta um circuito, a partir do seu id                           | Nenhuma                                 |
| PUT   | `/api/circuit/{id}`                    | Permite atualizar nome, pais e números de voltas de um circuito  | Nenhuma                                 |


### 3.2 Competition

| Verbo | Rota                                   | Descrição                                                      | Integração Necessária                    |
| ----- | -------------------------------------- | -------------------------------------------------------------- | ---------------------------------------- |
| POST  | `/api/competition/season/active`       | Retorna a season Ativa ou null                                 | Nenhuma                                  |
| POST  | `/api/competition/season/start`        | Cria a temporada, caledário de corridas e standings zerados    | Team Service (GET /drivers, GET /teams)  |
| POST  | `/api/competition/round:{int}/start`   | Tenta iniciar uma corrida, valida a ordem e o status           | Nenhuma                                  |
| GET   | `/api/competition/driverstanding`      | Retorna o ranking atualizado de Pilotos                        | Nenhuma                                  |
| GET   | `/api/competition/teamstanding`        | Retorna o ranking atualizado de Equipes                        | Nenhuma                                  |
| GET   | `/api/competition/races`               | Retorna o calendário com o status de cada etapa                | Nenhuma                                  |
| GET   | `/api/competition/races/inprogress`    | Retorna o obejto completo(join) de Races e circuits            | Nenhuma                                  |
| PATH  | `/api/competition/races/t1`            | Faz o update de Tl1 no banco                                   | Nenhuma                                  |
| PATH  | `/api/competition/races/t2`            | Faz o update de Tl2 no banco                                   | Nenhuma                                  |
| PATH  | `/api/competition/races/t3`            | Faz o update de Tl3 no banco                                   | Nenhuma                                  |
| PATH  | `/api/competition/races/qualifier`     | Faz o update de qualifier no banco                             | Nenhuma                                  |
| PATH  | `/api/competition/races/race`          | Faz o update de race (corrida oficial) no banco                | Nenhuma                                  |
| GET   | `/api/competition/driverstanding`      | Retorna a classificação atual dos pilotos                      | Nenhuma                                  |
| GET   | `/api/competition/teamstanding`        | Retorna a classificação atual das equipes                      | Nenhuma                                  |
| GET   | `/api/competition/calendar`            | Retorna a o calendário da seaon ativa                          | Nenhuma                                  |
| POST  | `/api/compettition/endrace`            | Finaliza a corrida, validando season e etapas da race          | Rabbit - consome a fila RaceFinishedEvent|
| POST  | `/api/competition/endseason`           | Finaliza a temporada, validando se o calendário foi finalizado | Nenhuma                                  |
| GET   | `/api/competition/seasons`             | Retorna todas as temporadas simuladas, inclusive as finalizadas| Nenhuma                                  |
---

## 4. Arquitetura de Mensageria (RabbitMQ)

A comunicação assíncrona é vital para o ciclo de vida da corrida.

O **Competition Service** atua como:
* **Consumidor** (eventos)

O serviço possuí um endpoint que consume a fila `RaceFinishedEvent` que o **Race Control** produz ao finaliza a simulação e consolida os resultados oficiais.

##### Json Esperado como retorno de `RaceFinishedEvent`

```json
{
   [
    { "driverId": "123e4567-e89b-12d3-a456-426614174000", "driverName": "Lewis Hamilton",  "teamId": "123e4567-c89b-12d3-b456-426614174000", "teamName": "Scuderia Ferrari", "Pontuatio": 25 },
    { "driverId": "123d4567-e89b-12d3-a456-426614174000", "driverName": "Fernando Alonso",  "teamId": "123g4567-c89b-12d3-b456-426614174000", "teamName": "Scuderia Ferrari", "Pontuatio": 18 },
    ...
  ]
}
```

#### Processamento ao Receber a Mensagem

* Aplica a **regra oficial de pontuação da F1** (25, 18, 15, ...).
* Soma os pontos em:

  * `DriverStandings`
  * `TeamStandings`
* Atualiza o status da corrida para `Finished`, liberando a próxima etapa.

---


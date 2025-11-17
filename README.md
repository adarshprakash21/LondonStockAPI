
# LondonStockAPI

REST API serves with different endpoints to excecute trades, get stock values, get average values , register users and login


## API Reference

#### Get average value of a stock

```http
  GET api/AuthController/{ticker}/value
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `ticker` | `string` | **Required**. ticker symbol of stock |

#### Post trades

```http
  POST /trades
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Ticker`      | `string` | **Required**. ticker symbol of stock |
| `Price`       | `decimal` | **Required**. traded price|
| `Shares`      | `decimal` | **Required**. number of shares|
| `BrokerId`    | `int` | **Required**. brocker id |


#### register user

```http
  POST /api/AuthController/register
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Username`| `string` | **Required**. username |
| `Password`| `string` | **Required**. password |


#### login user

```http
  POST /api/AuthController/login
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Username`| `string` | **Required**. username |
| `Password`| `string` | **Required**. password |



## Features

1. Jwt token authentication
2. Swagger UI
3. Dependency Injection of services in to persistent layer or controller
4. EFCore with code first approach
5. Attribute based routing
6. Sirilog implenetation


## Proposed Architecture
<img width="781" height="601" alt="LondonStockAPIArchitecture drawio" src="https://github.com/user-attachments/assets/e055bb3e-c552-421f-8ea7-d6b43028468e" />


## Optimizations

1. microservice architecture for stocks, trades and auth separately
2. API Gateway for security, routing and caching
3. Load balancers for even higher load applications to distribute the load
4. API Gateway and Load balancers combined for high end application architectures
5. Use AOuth.20 or PKCE for advance security features
6. Enable CORS to Cross-Origin Resource Sharing
7. Implement rate limiting
8. Can use Azure Service bus for messaging queue

## Deployment options
1. Develop CICD pipeline using Azure Devops using Docker file
2. Deploy the microservices into Azure App services
3. User App service Config to stire environmental variables
4. Make use of Azure SQL for databses
5. Monitor using Application Insights and alerts
6. Monitor logs using Kibana dashboard
7. User Azure Key Vaults to store credentials
8. Use web hooks to listen to artifactory and pull images to run in App service containers


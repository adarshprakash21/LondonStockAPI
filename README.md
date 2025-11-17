
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


## Architecture


## Optimizations

1. microservice architecture for stocks, trades and auth separately
2. API Gateway for security, routing and caching
3. Load balancers for even higher load applications to distribute the load
4. API Gateway and Load balancers combined for high end application architectures


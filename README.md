# StockAppWebApi

A web API for stock market data management and real-time quotes built with ASP.NET Core.

## Project Structure

```
StockAppWebApi/
├── mssql-compose/            # Docker configuration for MSSQL Server
├── python_app/              # Python scripts for data seeding
└── StockAppWebApi/          # Main ASP.NET Core Web API project
    ├── Attributes/         # Custom attributes for authentication
    ├── Controllers/        # API endpoints controllers
    ├── Extensions/         # Extension methods
    ├── Filters/           # Custom filters for request pipeline
    ├── Models/            # Data models and DB context
    ├── Repositories/      # Data access layer
    ├── Services/          # Business logic layer
    └── ViewModels/        # DTOs for API requests/responses
```

## Technology Stack

- ASP.NET Core 8.0
- MS SQL Server 2022 (Dockerized)
- Entity Framework Core
- JWT Authentication
- WebSocket for real-time quotes
- Python scripts for data seeding

## Prerequisites

- .NET 8.0 SDK
- Docker Desktop
- Python 3.x
- Visual Studio 2022 or VS Code

## Getting Started

### 1. Setup Database

```powershell
# Navigate to mssql-compose directory
cd mssql-compose

# Start MSSQL Server container
docker-compose up -d
```

### 2. Seed Data

```powershell
# Navigate to python_app directory
cd python_app

# Install required Python packages
pip install pyodbc faker

# Run seeding scripts in order
python insert_stocks.py
python insert_quotes.py
python insert_portfolios.py
python insert_watchlists.py
python insert_orders.py
python insert_etfs.py
python insert_etf_holdings.py
```

### 3. Run the API

```powershell
# Navigate to StockAppWebApi project directory
cd StockAppWebApi/StockAppWebApi

# Run the API
dotnet run
```

## Code Convention

1. **Naming Conventions**
   - Use PascalCase for class names, method names, and public properties
   - Use camelCase for local variables and private fields
   - Prefix interfaces with 'I'
   - Use meaningful and descriptive names

2. **Project Structure**
   - Follow clean architecture principles
   - Maintain separation of concerns between layers
   - Use dependency injection

3. **API Design**
   - RESTful endpoints following HTTP methods semantics
   - Use appropriate HTTP status codes
   - Versioning through URL when needed
   - Consistent response formats

4. **Security**
   - JWT authentication for protected endpoints
   - Input validation and sanitization
   - Secure communication over HTTPS

## Important Notice

**No Code Taking Policy**: This repository contains proprietary code and algorithms. Any unauthorized copying, modification, or distribution of the source code is strictly prohibited. The code is shared for reference and learning purposes only.

## Features

- Real-time stock quotes via WebSocket
- User authentication and authorization
- Portfolio management
- Watchlist functionality
- Order processing
- Covered Warrant support
- ETF holdings tracking

## API Documentation

The API endpoints can be tested using the provided HTTP files:
- `StockAppWebApi.http`
- `testRealtimeQuotes.html`
- `testWebSocket.html`

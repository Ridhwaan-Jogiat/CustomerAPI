## CustomerAPI - RESTful Customer Management Backend

A robust ASP.NET Core Web API built for managing customer data with full CRUD operations. This backend service provides a RESTful interface for customer management operations with built-in data validation and SQLite database persistence.

### Live API Access
**Base URL**: [https://customerapi-c2xz.onrender.com/api/customers](https://customerapi-c2xz.onrender.com/api/customers)

⚠️ **Important**: The API is hosted on Render's free tier. The server goes to sleep after 15 minutes of inactivity. **First requests will take 20-30 seconds** while the server wakes up. Subsequent requests will respond normally.

### Key Features
- **RESTful API** endpoints for Create, Read, Update, Delete operations
- **SQLite Database** with Entity Framework Core for data persistence
- **Search Functionality** across multiple customer fields
- **CORS Support** for cross-origin requests from frontend applications
- **Swagger/OpenAPI** documentation for API exploration and testing
- **Input Validation** with data annotations and model validation
- **Zero Configuration** database setup - SQLite file is auto-generated

### Technical Stack
- ASP.NET Core 6.0+ Web API
- Entity Framework Core (Code First approach)
- SQLite Database
- Swagger UI for API documentation
- Deployed on Render (Free Tier)

### API Endpoints
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/customers` | Retrieve all customers with optional search |
| GET | `/api/customers/{id}` | Get specific customer details |
| POST | `/api/customers` | Create new customer |
| PUT | `/api/customers/{id}` | Update existing customer |
| DELETE | `/api/customers/{id}` | Remove customer |

### Local Development
```bash
dotnet restore
dotnet run

# LogiTrack - Order Management API

A comprehensive order management and inventory tracking API built with ASP.NET Core 9, featuring JWT authentication, role-based authorization, and SQLite database. LogiTrack provides a robust solution for managing orders, tracking inventory, and handling user authentication in a modern web application.

## 📦 Project Overview

LogiTrack is a production-ready order management system that combines inventory tracking with order processing capabilities. It features secure user authentication, role-based access control, and efficient data management using Entity Framework Core with SQLite. The API provides RESTful endpoints for managing inventory items, processing orders, and handling user authentication with JWT tokens.

## ✨ Features

### 📋 Order Management
- **Order Creation** - Create new orders with multiple inventory items
- **Order Retrieval** - Get all orders or specific order by ID
- **Order Deletion** - Remove orders from the system
- **Order Validation** - Validate inventory items before order creation
- **Order Tracking** - Track order dates and customer information

### 📦 Inventory Management
- **Inventory Tracking** - Manage inventory items with quantities and locations
- **Item Addition** - Add new inventory items to the system
- **Item Deletion** - Remove inventory items
- **Caching** - Memory caching for improved performance
- **Stock Management** - Track item quantities and locations

### 🔐 Authentication & Authorization
- **JWT Token Authentication** - Secure token-based authentication
- **User Registration** - Secure account creation
- **User Login** - Secure login with JWT token generation
- **Role-Based Authorization** - Manager and User role support
- **Password Security** - Secure password handling with ASP.NET Core Identity

### 🏗️ Architecture & Design
- **RESTful API Design** - Standard REST API endpoints
- **Entity Framework Core** - Modern ORM with SQLite support
- **Dependency Injection** - Modern .NET dependency injection patterns
- **Memory Caching** - Performance optimization with caching
- **Clean Architecture** - Separation of concerns with controllers, models, and data layers

### 🔧 Development Features
- **Swagger Documentation** - Interactive API documentation
- **SQLite Database** - Lightweight, file-based database
- **Entity Framework Migrations** - Database version control
- **Configuration Management** - Environment-based configuration
- **Logging** - Structured logging with configurable levels

## 🛠️ Technologies Used

### Core Framework
- **ASP.NET Core 9** - Modern web framework for building APIs
- **Entity Framework Core 9.0.6** - Object-relational mapping
- **ASP.NET Core Identity 9.0.6** - User management and authentication

### Authentication & Security
- **JWT Bearer Authentication 9.0.6** - JSON Web Token implementation
- **System.IdentityModel.Tokens.Jwt 8.12.0** - JWT token handling
- **Microsoft Identity Model** - Security token handling

### Database & Storage
- **SQLite 9.0.6** - Lightweight, file-based database
- **Entity Framework Tools 9.0.6** - Database migration and management
- **Memory Caching** - In-memory caching for performance

### Development Tools
- **Swashbuckle.AspNetCore 9.0.1** - Swagger/OpenAPI documentation
- **Microsoft.AspNetCore.OpenApi 9.0.6** - OpenAPI integration

## 🚀 Getting Started

### Prerequisites
- **.NET 9 SDK** - Latest .NET 9 runtime and SDK
- **Visual Studio 2022** or **VS Code** - Development environment
- **Postman** or **curl** - API testing tools

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/SametDulger/LogiTrackOrderManagementAPI.git
   cd LogiTrackOrderManagementAPI
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

4. **Configure environment**
   - Update `appsettings.json` with your JWT secret key
   - Configure database connection strings if needed

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the application**
   - **API**: `https://localhost:7134` (HTTPS) or `http://localhost:5134` (HTTP)
   - **Swagger UI**: `https://localhost:7134/swagger`

## 📁 Project Structure

```
LogiTrackOrderManagementAPI/
├── Controllers/                 # API Controllers
│   ├── AuthController.cs       # Authentication endpoints
│   ├── OrderController.cs      # Order management endpoints
│   └── InventoryController.cs  # Inventory management endpoints
├── Data/                       # Data Access Layer
│   └── LogiTrackContext.cs     # Entity Framework context
├── Models/                     # Data Models
│   ├── ApplicationUser.cs      # User model
│   ├── Order.cs               # Order entity model
│   └── InventoryItem.cs       # Inventory item model
├── Migrations/                 # Database Migrations
│   ├── InitialCreate.cs       # Initial database schema
│   └── ModelSnapshot.cs       # Current model snapshot
├── Properties/                 # Project properties
├── Program.cs                  # Application entry point
├── LogiTrack.csproj           # Project file
├── appsettings.json           # Configuration settings
├── logitrack.db               # SQLite database file
└── README.md                  # Project documentation
```

## 🔌 API Endpoints

### Authentication Endpoints

#### User Registration
```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "SecurePass123!",
  "confirmPassword": "SecurePass123!"
}
```

**Response:**
```json
{
  "message": "User registered successfully"
}
```

#### User Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "SecurePass123!"
}
```

**Response:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Order Management Endpoints

#### Get All Orders
```http
GET /api/order
Authorization: Bearer {token}
```

#### Get Order by ID
```http
GET /api/order/{id}
Authorization: Bearer {token}
```

#### Create New Order
```http
POST /api/order
Authorization: Bearer {token}
Content-Type: application/json

{
  "customerName": "John Doe",
  "items": [
    {
      "id": 1
    },
    {
      "id": 2
    }
  ]
}
```

#### Delete Order
```http
DELETE /api/order/{id}
Authorization: Bearer {token}
```

### Inventory Management Endpoints

#### Get All Inventory Items
```http
GET /api/inventory
Authorization: Bearer {token}
```

#### Add Inventory Item
```http
POST /api/inventory
Authorization: Bearer {token}
Content-Type: application/json

{
  "name": "Product Name",
  "quantity": 100,
  "location": "Warehouse A"
}
```

#### Delete Inventory Item
```http
DELETE /api/inventory/{id}
Authorization: Bearer {token}
```

## 📊 Data Models

### Order Model
```csharp
public class Order
{
    public int Id { get; set; }
    
    [Required]
    public string CustomerName { get; set; }
    
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    
    public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
}
```

### InventoryItem Model
```csharp
public class InventoryItem
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public int Quantity { get; set; }
    
    public string? Location { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
```

### ApplicationUser Model
```csharp
public class ApplicationUser : IdentityUser
{
    // Extends IdentityUser with custom properties if needed
}
```

## 🔧 Configuration

### JWT Settings
```json
{
  "Jwt": {
    "Key": "your-super-secret-jwt-key-here",
    "Issuer": "LogiTrackAPI",
    "Audience": "LogiTrackUsers",
    "ExpiresInMinutes": 60
  }
}
```

### Database Configuration
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=logitrack.db"
  }
}
```

### Caching Configuration
- **Memory Cache**: 30-second sliding expiration for inventory items
- **Cache Invalidation**: Automatic cache clearing on data changes

## 🧪 Testing

### Using Swagger UI
1. Navigate to `https://localhost:7134/swagger`
2. Test endpoints directly in the browser
3. View request/response schemas
4. Execute API calls with sample data

### Using HTTP Files
```bash
# Test registration
curl -X POST "https://localhost:7134/api/auth/register" \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"TestPass123!","confirmPassword":"TestPass123!"}'

# Test login
curl -X POST "https://localhost:7134/api/auth/login" \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","password":"TestPass123!"}'

# Test inventory (with token)
curl -X GET "https://localhost:7134/api/inventory" \
  -H "Authorization: Bearer {your-token-here}"
```

### Using Postman
1. Import the API endpoints
2. Set up environment variables for tokens
3. Test authentication flow
4. Test order and inventory operations

## 🚀 Deployment

### Development Deployment
```bash
dotnet run --environment Development
```

### Production Deployment
```bash
# Build for production
dotnet publish -c Release

# Run with production configuration
dotnet run --environment Production
```

### Docker Deployment
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["LogiTrack.csproj", "./"]
RUN dotnet restore "LogiTrack.csproj"
COPY . .
RUN dotnet build "LogiTrack.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogiTrack.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogiTrack.dll"]
```

## 🔒 Security Considerations

### Authentication & Authorization
- **JWT Token Security**: Configurable token expiration and validation
- **Role-Based Access**: Manager and User role differentiation
- **Password Policies**: Secure password handling with Identity
- **Input Validation**: Comprehensive model validation

### Production Security
- **Change JWT Secret**: Use a strong, unique secret key
- **Enable HTTPS**: Configure SSL certificates
- **Database Security**: Use secure database connections
- **Environment Variables**: Store secrets in environment variables
- **CORS Policy**: Configure appropriate CORS policies
- **Rate Limiting**: Implement API rate limiting

## 📈 Performance Features

### Caching Strategy
- **Memory Caching**: 30-second sliding expiration for inventory
- **Cache Invalidation**: Automatic cache clearing on data changes
- **Performance Optimization**: Reduced database queries

### Database Optimization
- **SQLite**: Lightweight, file-based database
- **Entity Framework**: Efficient ORM with lazy loading
- **AsNoTracking**: Optimized read operations
- **Include Statements**: Efficient data loading

## 🤝 Contributing

1. **Fork the repository**
2. **Create a feature branch** (`git checkout -b feature/amazing-feature`)
3. **Commit your changes** (`git commit -m 'Add some amazing feature'`)
4. **Push to the branch** (`git push origin feature/amazing-feature`)
5. **Open a Pull Request**

### Development Guidelines
- Follow C# coding conventions
- Add unit tests for new features
- Update documentation as needed
- Ensure security best practices
- Test thoroughly before submitting

## 🔮 Future Enhancements

### Planned Features
- **Email Notifications** - Order confirmation and status updates
- **Inventory Alerts** - Low stock notifications
- **Order Status Tracking** - Order lifecycle management
- **Reporting Dashboard** - Analytics and reporting features
- **Bulk Operations** - Batch order and inventory operations
- **Audit Logging** - Comprehensive activity tracking

### Technical Improvements
- **Redis Caching** - Distributed caching for scalability
- **Database Migrations** - Advanced migration strategies
- **Health Checks** - Application health monitoring
- **API Versioning** - Version control for API endpoints
- **Rate Limiting** - API usage throttling
- **Monitoring & Analytics** - Application insights

## 📝 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- **Microsoft ASP.NET Core Team** - Excellent web framework
- **Entity Framework Team** - Powerful ORM solution
- **SQLite Team** - Lightweight database solution
- **JWT.io** - JSON Web Token standards

## 📚 Learning Resources

### Documentation
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)
- [SQLite Documentation](https://www.sqlite.org/docs.html)

### Tutorials
- [Building Web APIs with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/web-api/)
- [Entity Framework Core with SQLite](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app)
- [JWT Authentication Best Practices](https://auth0.com/blog/a-look-at-the-latest-draft-for-jwt-bcp/)

## 📞 Support

For questions, issues, or contributions:
- **Issues**: [GitHub Issues](https://github.com/SametDulger/LogiTrackOrderManagementAPI/issues)
- **Discussions**: [GitHub Discussions](https://github.com/SametDulger/LogiTrackOrderManagementAPI/discussions)

## 🌟 Key Highlights

### Order Management Excellence
- **Comprehensive Order Processing** - Full order lifecycle management
- **Inventory Integration** - Seamless inventory and order coordination
- **Validation & Security** - Robust data validation and security
- **Performance Optimization** - Caching and efficient data access

### Modern Architecture
- **ASP.NET Core 9** - Latest .NET framework features
- **Clean Architecture** - Separation of concerns
- **RESTful Design** - Standard API conventions
- **Entity Framework Core** - Modern ORM with SQLite

### Developer Experience
- **Swagger Documentation** - Interactive API testing
- **SQLite Database** - Easy development and deployment
- **Comprehensive Logging** - Debugging and monitoring
- **Production Ready** - Scalable and maintainable

---

**Built with ❤️ using ASP.NET Core 9, Entity Framework Core, and SQLite**

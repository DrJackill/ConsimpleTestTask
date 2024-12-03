# Consimple API  
Consimple API is a backend application developed using ASP.NET Core, .NET 8, and EF Core 8.
# [Little demo about app](https://drive.google.com/file/d/1xXA2fEK2mgEyQ0VT3n_8MHQ0_IVmEhhC/view?usp=sharing)

## Features  
- **Transaction Management**: Create, retrieve, and manage client transactions.  
- **Database Integration**: Robust support with PostgreSQL 17 using Entity Framework Core.  

## Prerequisites  
Ensure you have the following installed:  
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- PostgreSQL 17  

## Installation  
1. **Clone the Repository**  
   ```bash  
   git clone <repository-url>  
   cd wallet-api  
   ```
2. **Install Dependencies**
   ```bash
   dotnet restore
   ```
3. **Configure Database**
   Update the PostgreSQL connection string in `appsettings.json`
   ```json
   "ConnectionStrings": {  
      "DefaultConnection": "Server=yourHost;Port=5432;Database=YourDBName;User Id=yourUserId;Password=YourPassword;"  
    }  
   ```
4. **Apply Database Migrations**
   Run migrations to set up the database schema:
   ```bash
   dotnet ef database update
   ```
5. **Run the Application**
   Start the API server:
   ```bash
   dotnet run  
   ```
   
## API Documentation
The API is documented with Swagger. After running the application, you can access the Swagger UI at:
```bash
http://localhost:<port>/swagger
```
It provides detailed information about the endpoints, request/response models, and example usage.

# Banking.API

Banking API
This is the backend for the simulated banking application. The API is built with ASP.NET Core and provides endpoints for user and bank account management.

Features
User Management:
Create new users.
Check if a username is already in use.
Authenticate users with hashed passwords.
Bank Account Management:
Link users to bank accounts during registration.
Fetch bank account details.
Endpoints
User Endpoints
POST /api/users/signup

Create a new user and link a bank account.
Request Body:
{
  "username": "string",
  "password": "string",
  "firstName": "string",
  "lastName": "string",
  "address": "string",
  "phoneNumber": "string",
  "accountType": "Checking|Savings|Business"
}
Response:
{
  "userId": 1,
  "firstName": "string",
  "lastName": "string",
  "accountType": "Checking",
  "balance": 0
}
POST /api/users/login

Authenticate a user.
Request Body:
{
  "username": "string",
  "password": "string"
}
Response:
{
  "userId": 1,
  "firstName": "string",
  "lastName": "string"
}
**Bank Account Endpoints**
Future endpoints for deposits, withdrawals, and balance inquiries will be added.

**Requirements**
.NET Core SDK (version 8 or higher)
PostgreSQL database

Setup
Clone the repository:
git clone https://github.com/kirillyakubov101/BankingApp.API.git
Update appsettings.json with your PostgreSQL connection string:
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=BankDB;Username=postgres;Password=yourpassword"
}
Apply migrations and update the database:
dotnet ef migrations add InitialCreate
dotnet ef database update
Run the API:
dotnet run

**Future Features**
Deposit and withdrawal functionality.
Transaction history endpoints.
JWT authentication for secure access.

**Contributing**
Contributions are welcome! Submit a pull request or open an issue for discussion.


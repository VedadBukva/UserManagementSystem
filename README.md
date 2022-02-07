# User Management System

The application was written in ASP.NET Core version 3.1. If you want to test the application, first make sure you have installed:   
- [.NET 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)

## Database setup
For purpose of this project was used SQL Server in SQL Server Management Studio (SSMS)
For the purpose of testing the application, a script called "UMS_DbPrepare.sql" was prepared, 
which is located at the root of the repository and is used to prepare the database. 

Steps you need to take: 
- 1. On your server in SSMS create database with name [UserManagementSystem]
- 2. Open "UMS_DbPrepare.sql" script in new window of SSMS and execute script (F5)
- 3. make sure your connection string is correct (you can modify it in `appsettings.json`) 

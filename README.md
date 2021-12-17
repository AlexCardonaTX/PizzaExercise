# PizzaApp

This is an Web Application created using .Net Core 5.0, as an excercise. It allows to manage (Create, Delete, Update, Read) ingredients and pizzas as well as their relations.

## Launch The Application

To run the application after clonning the repository, you should navigate to the folder that contains the solution file:
```
cd PizzaHut\PizzaApp\
```
And Execute the restore command for dotnet:
```
dotnet restore
```
After that navigate to the PizzaApp folder and Run the project:
```
cd PizzaApp
dotnet run
```
If you are using Visual Studio you can just Run the `Development` profile for the PizzaApp project (Presentation layer). As this is the only profile it is not needed to specify in the console command.

This should launch the application in http://localhost:5001 and http://localhost:5000.

## Swagger

The application has Swagger configurated in http://localhost:5000/swagger/index.html, or the same url for the 5001 port.

## Technologies and Dependencies

The proyect was created using .Net Core 5.0, and has the following dependencies:

* Microsoft.NET.Test.Sdk - 16.9.4
* Moq - 4.16.1
* NUnit - 3.13.1
* NUnit3TestAdapter - 3.17.0
* coverlet.collector - 3.0.2
* Swashbuckle.AspNetCore - 5.6.3
* Microsoft.EntityFrameworkCore - 5.0.12
* Microsoft.EntityFrameworkCore.SqlServer - 5.0.12
* Microsoft.Extensions.Configuration.Abstractions - 5.0.0

And it also uses a Microsoft SQL Server DataBase.

## Setting Up the DB

1) Create a DB named `PizzaAppDB` with SQL Manager.
2) Locate the folder `PizzaHut\PizzaApp\PizzaAppData\Scripts`.
3) Create a new query and execute the `Schema.sql` script.
4) Create a new query and execute the `Data.sql` scrip.

The Application uses the next configuration for the conection string:
```
"DBConnection": "Server=tcp:localhost,1433;Initial Catalog=PizzaAppDB;Integrated Security=True;"
```
And can be changed in the `appsettings.Development.json` file from the Presentation layer if needed.

## Unit Tests

There are 2 unit tests for the proyect and they are located in the UnitTest project of the solution. And can be tested from the `PizzaHut\PizzaApp\` folder:
```
dotnet test
```
Or also can be tested with the contextual menu from Visual Studio.

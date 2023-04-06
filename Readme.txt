The following steps were taken during this test:

STEP 1:

I downloaded the NorthWnd database and attached it via SSMS.
I wrote the attached SQL query to create the relevant stored procedure.

STEP 2:

I created an API using .Net6
I installed Microsoft.EntityFrameworkCore.Sqlite nuget package, and added a connectionstring in the appsettings.json file
I created a DataContext class to access the data through EF
I installed EF Core tools via command: dotnet tool install -g dotnet-ef
I added the Microsoft.EntityFrameworkCore.Design nuget package
I added EF Core migrations to create the database from code
I installed the SQLite and SQL Server Compact Toolbox to VS
I added the possible bet placement combinations into the PlaceTypeCombinations table (imported from csv file)
I coded the API with relevant methods

I was still busy with creating the unit tests, but I wanted to get this through to you before the long weekend, so I hope you understand...

Kind regards

Johan

The Solution contains 3 projects
1.Xlogia.Domain : Contains Model and persistance code using entity framework.
2.Xlogia : Contains mvc application.
3.Xlogia.Tests : Contains unit tests for EmployeeController.

To run the project just change Xlogia=>web.config
Change connection string => EFDbContext 
<add name="EFDbContext" connectionString="Data Source=LAPTOP-L4CRCC5J;Initial Catalog=XLogia;User ID=sa;Password=Test@123" providerName="System.Data.SqlClient" />

just point DataSource to a sql server instance, with sa credentials, and database and schema will be 
created out of the box for you.

You can also point connection string to a database with sa credentials and schema will be created out 
of the box for you.
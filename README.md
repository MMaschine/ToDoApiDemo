Simple API example with minimal functionality (EF, migrations error interception) for demo purposes

The solution configured for local setup and to work with MS SQL

- open in VS
- in appsettings.json add into ConnectionStrings element your connection string like: "ToDoDatabase":"Data Source={Your server name};Initial Catalog={Your DB namme};User ID={Your user};password={Your password};", 
	other parameters depend on your server's config
- Run the app in Debug mode to have access for Swagger UI

Note: 
To have access to in-design time migrations add your connection string also in DesignTimeDbContextFactory	in ToDoApp.DataAccess 

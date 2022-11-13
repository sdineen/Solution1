# MIGRATIONS
#dotnet tool update --global dotnet-ef
# -p The target project (containing DbContext)
# -s Relative path to the project folder of the startup project
dotnet ef migrations add Initial -p ClassLibrary -s WebAppp
dotnet ef database update -p ClassLibrary1 -s WebApi1
Write-Output "Migrations completed (created tables)"
#reference https://stackoverflow.com/questions/69544799/dotnet-ef-separate-database-provider-for-dev-prod

[CmdletBinding()]
param(
    [string]$Name
);

$prev = $Env:ASPNETCORE_ENVIRONMENT;
Write-Host "Previous env=""$prev""";
try {
    Write-Host "Adding migration for production";
    $Env:ASPNETCORE_ENVIRONMENT = "Production";
    dotnet ef migrations add $Name `
        --context "DataContext" `
        --output-dir "Data/Migrations/SqlServerMigrations" `
		--project ".\AuthAPI\AuthAPI.csproj";
        
    Write-Host "Adding migration for development";
    $Env:ASPNETCORE_ENVIRONMENT = "Development";
    dotnet ef migrations add $Name `
        --context "DataContextDevelopment" `
        --output-dir "Data/Migrations/SqliteMigrations" `
		--project ".\AuthAPI\AuthAPI.csproj";
}
finally {
    Write-Host "Restoring env=""$prev""";
    $Env:ASPNETCORE_ENVIRONMENT = $prev;
}
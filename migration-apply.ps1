#reference https://stackoverflow.com/questions/69544799/dotnet-ef-separate-database-provider-for-dev-prod

[CmdletBinding()]
param(
    [string]
    [ValidateSet("Development", "Production")]
    $Environment
)

$context = @{
    "Development" = "DataContextDevelopment" 
    "Production"  = "DataContext"
}.$Environment;

$prev=$Env:ASPNETCORE_ENVIRONMENT;
try {
    $Env:ASPNETCORE_ENVIRONMENT=$Environment;
    dotnet ef database update --context $context --project "AuthAPI\AuthAPI.csproj";
}
finally {
    Write-Host "Restoring env=""$prev""";
    $Env:ASPNETCORE_ENVIRONMENT = $prev;
}
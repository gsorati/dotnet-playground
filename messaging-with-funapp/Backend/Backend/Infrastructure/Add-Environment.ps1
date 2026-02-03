param (
    [string]$resourceGroup = "rg-messaging",
    [string]$location = "eastus",
    [string]$namespaceName = "sb-messaging",
    [string]$queueName = "messaging-queue",
    [string]$appsettingsPath = "../appsettings.json"
)

# Login if not already
az account show > $null 2>&1
if ($LASTEXITCODE -ne 0) 
{
    Write-Host "Logging in to Azure..."
    az login --identity --only-show-errors
}

# Check and create resource group
if (-not (az group show --name $resourceGroup --output none 2>$null)) 
{
    Write-Host "Creating resource group: $resourceGroup"
    az group create --name $resourceGroup --location $location --output none
} else 
{
    Write-Host "Resource group already exists: $resourceGroup"
}

# Check and create namespace
if (-not (az servicebus namespace show --name $namespaceName --resource-group $resourceGroup --output none 2>$null)) 
{
    Write-Host "Creating Service Bus namespace: $namespaceName"
    az servicebus namespace create `
        --resource-group $resourceGroup `
        --name $namespaceName `
        --location $location `
        --sku Standard `
        --output none
} else 
{
    Write-Host "Namespace already exists: $namespaceName"
}

# Check and create queue
if (-not (az servicebus queue show --resource-group $resourceGroup --namespace-name $namespaceName --name $queueName --output none 2>$null)) 
{
    Write-Host "Creating Service Bus queue: $queueName"
    az servicebus queue create `
        --resource-group $resourceGroup `
        --namespace-name $namespaceName `
        --name $queueName `
        --output none
} else 
{
    Write-Host "Queue already exists: $queueName"
}

# Get connection string
$connectionString = az servicebus namespace authorization-rule keys list `
    --resource-group $resourceGroup `
    --namespace-name $namespaceName `
    --name RootManageSharedAccessKey `
    --query primaryConnectionString -o tsv

Write-Host "Service Bus connection string retrieved."

# Update appsettings.json
$appsettings = Get-Content $appsettingsPath | ConvertFrom-Json
if (-not $appsettings.ConnectionStrings) 
{
    $appsettings | Add-Member -MemberType NoteProperty -Name ConnectionStrings -Value @{}
}
$appsettings.ConnectionStrings.ServiceBus = $connectionString
$appsettings | ConvertTo-Json -Depth 5 | Set-Content $appsettingsPath

Write-Host "✅ Updated connection string in appsettings.json successfully."
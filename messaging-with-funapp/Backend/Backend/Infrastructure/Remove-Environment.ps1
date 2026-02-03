param (
    [string]$resourceGroup = "rg-messaging"
)

# Login if not already
# az login --only-show-errors

Write-Host "Deleting resource group: $resourceGroup"
az group delete --name $resourceGroup --yes --no-wait

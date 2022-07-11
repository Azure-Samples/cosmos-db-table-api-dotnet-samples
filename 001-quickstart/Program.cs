// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using Azure.Data.Tables;
// </using_directives>

// <client_credentials> 
// New instance of the TableClient class
TableServiceClient tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));
// </client_credentials>

// <create_table>
// New instance of TableClient class referencing the server-side table
TableClient tableClient = tableServiceClient.GetTableClient(
    tableName: "adventureworks"
);

await tableClient.CreateIfNotExistsAsync();
// </create_table>

// <create_object_add> 
// Create new item using composite key constructor
var prod1 = new Product()
{
    RowKey = "68719518388",
    PartitionKey = "gear-surf-surfboards",
    Name = "Ocean Surfboard",
    Quantity = 8,
    Sale = true
};

// Add new item to server-side table
await tableClient.AddEntityAsync<Product>(prod1);
// </create_object_add>

// <read_item> 
// Read a single item from container
var product = await tableClient.GetEntityAsync<Product>(
    rowKey: "68719518388",
    partitionKey: "gear-surf-surfboards"
);
Console.WriteLine("Single product:");
Console.WriteLine(product.Value.Name);
// </read_item>

// <query_items> 
// Read multiple items from container
var prod2 = new Product()
{
    RowKey = "68719518390",
    PartitionKey = "gear-surf-surfboards",
    Name = "Sand Surfboard",
    Quantity = 5,
    Sale = false
};

await tableClient.AddEntityAsync<Product>(prod2);

var products = tableClient.Query<Product>(x => x.PartitionKey == "gear-surf-surfboards");

Console.WriteLine("Multiple products:");
foreach (var item in products)
{
    Console.WriteLine(item.Name);
}
// </query_items>

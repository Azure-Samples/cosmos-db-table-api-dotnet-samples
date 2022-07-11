// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using Azure;
using Azure.Data.Tables;
// </using_directives>

// <client_credentials> 
// New instance of the TableClient class
var _tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));
// </client_credentials>

// <create_table>
// New instance of TableClient class referencing the server-side table
TableClient tableClient = _tableServiceClient.GetTableClient(
    tableName: "adventureworks"
);

await tableClient.CreateIfNotExistsAsync();
// </create_table>

// <create_object_add> 
// Create new item using composite key constructor
TableEntity item1 = new(
    rowKey: "68719518388",
    partitionKey: "gear-surf-surfboards"
);

// Add properties to item
item1.Add("Name", "Yamba Surfboard");
item1.Add("Quantity", 5);
item1.Add("Sale", false);

// Add new item to server-side table
await tableClient.AddEntityAsync<TableEntity>(item1);
// </create_object_add>

// <read_item> 
// Read a single item from container
var product = await tableClient.GetEntityAsync<TableEntity>(
    rowKey: "68719518388",
    partitionKey: "gear-surf-surfboards"
);
Console.WriteLine("Single product:");
Console.WriteLine(product.Name);
// </read_item>

// <query_items> 
// Read multiple items from container
var prod = new Product()
{
    PartitionKey = "Products",
    RowKey = Guid.NewGuid().ToString(),
    Category = "gear-surf-surfboards",
    Name = "Sand Surfboard",
    Quantity = 8,
    Sale = true
};

_tableClient.AddEntity<Product>(prod);

var products = _tableClient.Query<Product>(x => x.Category == "gear-surf-surfboards");

Console.WriteLine("Multiple products:");
foreach (var item in products)
{
    Console.WriteLine(item.Name);
}
// </query_items>
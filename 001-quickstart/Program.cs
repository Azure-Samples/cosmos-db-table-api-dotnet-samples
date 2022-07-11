// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using Azure.Data.Tables;
// </using_directives>

// <client_credentials> 
// New instance of the TableClient class
TableServiceClient client = new TableServiceClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));
// </client_credentials>

// <create_table>
// New instance of TableClient class referencing the server-side table
TableClient tableClient = client.GetTableClient(
    tableName: "adventureworks2"
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
Console.WriteLine(product.Value["Name"]);
// </read_item>

// <query_items> 
// Read multiple items from container
TableEntity item2 = new(
    rowKey: "68719518399",
    partitionKey: "gear-surf-surfboards"
);

// Add properties to item
item2.Add("Name", "Sand Surfboard");
item2.Add("Quantity", 8);
item2.Add("Sale", true);


tableClient.AddEntity<TableEntity>(item2);

var products = tableClient.Query<TableEntity>(filter: $"PartitionKey eq 'gear-surf-surfboards'");

Console.WriteLine("Multiple products:");
foreach (var item in products)
{
    Console.WriteLine(item["Name"]);
}
// </query_items>
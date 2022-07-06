// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using Azure.Data.Tables;
// </using_directives>

// <connection_string> 
// New instance of TableServiceClient class using a connection string
TableServiceClient client = new(
    connectionString: Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING")!
);
// </connection_string>

// <get_table>
// Get instance of TableClient class referencing the server-side table
TableClient tableClient = client.GetTableClient(
    tableName: "adventureworks"
);
// </get_table>

// <create_object_add> 
// Create new item using composite key constructor
TableEntity item1 = new(
    rowKey: "68719518388",
    partitionKey: "gear-surf-surfboards"
);

// Add properties to item
item1.Add("Name", "Sunnox Surfboard");
item1.Add("Quantity", 8);
item1.Add("Sale", true);

// Add new item to server-side table
await tableClient.AddEntityAsync<TableEntity>(item1);
// </create_object_add>

// <create_object_dictionary> 
// Create dictionary
Dictionary<string, object> properties = new()
{
    { "RowKey", "68719518388" },
    { "PartitionKey", "gear-surf-surfboards" },
    { "Name", "Sunnox Surfboard" },
    { "Quantity", 8 },
    { "Sale", true }
};

// Create new item using dictionary constructor
TableEntity item2 = new(
    values: properties
);

// Add new item to server-side table
await tableClient.AddEntityAsync<TableEntity>(item2);
// </create_object_dictionary>
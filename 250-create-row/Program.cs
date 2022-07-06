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

// <create_object> 
// Create new row and add to table
Product row = new ()
{   
    RowKey = "68719518388",
    PartitionKey = "gear-surf-surfboards",
    Name = "Sunnox Surfboard",
    Quantity = 8,
    Sale = true
};
// </create_object> 

// <create_row>
// Add new row (entity) to server-side table
await tableClient.AddEntityAsync<Product>(row);
// </create_row>
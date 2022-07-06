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

// <create_table>
// New instance of TableClient class referencing the server-side table
TableClient tableClient1 = client.GetTableClient(
    tableName: "adventureworks-1"
);

await tableClient1.CreateAsync();
// </create_table>

// <create_table_check>
// New instance of TableClient class referencing the server-side table
TableClient tableClient2 = client.GetTableClient(
    tableName: "adventureworks-2"
);

await tableClient2.CreateIfNotExistsAsync();
// </create_table_check>
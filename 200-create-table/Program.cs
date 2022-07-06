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
TableClient tableClient = client.GetTableClient(
    tableName: "adventureworks"
);

await tableClient.CreateIfNotExistsAsync();
// </create_table>
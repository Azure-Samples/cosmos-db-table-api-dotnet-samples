// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_identity_directives> 
using Azure.Core;
using Azure.Identity;
// </using_identity_directives>
// <using_directives> 
using Azure.Data.Tables;
// </using_directives>

// <credential>
// Custom credential class for servers and clients outside of Azure
TokenCredential credential = new ClientSecretCredential(
    tenantId: Environment.GetEnvironmentVariable("AAD_TENANT_ID")!,
    clientId: Environment.GetEnvironmentVariable("AAD_CLIENT_ID")!,
    clientSecret: Environment.GetEnvironmentVariable("AAD_CLIENT_SECRET")!,
    options: new TokenCredentialOptions()
);
// </credential>

// <secret_credential> 
// New instance of TableServiceClient class using a credential
TableServiceClient client = new(
    endpoint: new Uri(Environment.GetEnvironmentVariable("COSMOS_ENDPOINT")!),
    tokenCredential: credential
);
// </secret_credential> 
# Getting Started with GraphQL on ASP.NET Core and Hot Chocolate - Workshop

This guide outlines how to secure a GraphQL server built with ASP.NET Core and Hot Chocolate using the OAuth 2.0 client credentials flow. It assumes you're familiar with basic GraphQL, ASP.NET Core, and Azure concepts.

**Workshop Resources:** [http://workshop.chillicream.com/](http://workshop.chillicream.com/)

## Securing the GraphQL Server with OAuth 2.0 Client Credentials Flow

This workshop will utilize the client credentials flow for authenticating applications to access the GraphQL server. This method is ideal for server-to-server communication where a user context isn't involved.

### Setting up Microsoft Entra ID

We will configure Microsoft Entra ID (formerly Azure Active Directory) to handle authentication and authorization.

#### 1. Create Application Registrations

We need to register two applications in your Azure directory's Microsoft Entra ID:

*   **GraphQL.Server:** Represents your GraphQL API.
*   **GraphQL.Client.WebApi:** Represents a client application that will consume the GraphQL API.

**Steps to create:**

1.  Go to your Azure directory.
2.  Navigate to **Microsoft Entra ID**.
3.  Select **App registrations** from the left sidebar.
4.  Click **New registration** and create each application (GraphQL.Server and GraphQL.Client.WebApi).

#### 2. Configure GraphQL.Server

Since we're using the client credentials flow (application-level authentication), we need to define roles that will be assigned to applications.

##### Create an App Role

1.  In the **GraphQL.Server** application registration, go to **App roles** in the left sidebar.
2.  Click **Create app role**.
3.  Configure the app role:
    *   **Display name:** (e.g., "API.Access" or a more specific role)
    *   **Allowed member types:** **Applications** (this is crucial for client credentials flow).
    *   **Value:** This is the name of the role that will be granted (e.g., "API.Access").
    *   **Description:** Describe what the role allows.
    *   **Do you want to enable this app role?** Checked

#### 3. Configure GraphQL.Client.WebApi

This application needs permissions to access GraphQL.Server and a way to authenticate itself.

##### Grant API Permissions

1.  In the **GraphQL.Client.WebApi** application, select **API permissions** from the left sidebar.
2.  Click **Add a permission**.
3.  Choose **APIs my organization uses** and find/select **GraphQL.Server**.
4.  Select **Application permissions**.
5.  Check the app role(s) you created for GraphQL.Server (e.g., "API.Access") that this client application needs.
6.  Click **Add permissions**.
7.  Finally, click **Grant admin consent for \[Your Directory Name]**. This is important to avoid consent prompts during the authentication process.

##### Create a Client Secret

1.  In the **GraphQL.Client.WebApi** application, go to **Certificates & secrets** in the left sidebar.
2.  Click **New client secret**.
3.  Provide a description and set an expiration period.
4.  Click **Add**.
5.  **Important:** Copy the secret's **Value** immediately. You won't be able to see it again. This value will be used by the client application to authenticate.

### Configure and Run Applications

Update the configuration (e.g., `appsettings.json`) of both your **GraphQL.Server** and **GraphQL.Client.WebApi** projects to include:

*   **Tenant ID:** The ID of your Azure directory.
*   **Client IDs:** The application (client) IDs of both GraphQL.Server and GraphQL.Client.WebApi.
*   **Client Secret:** The secret you created for GraphQL.Client.WebApi.
*   **Authority URL:**  `https://login.microsoftonline.com/{YourTenantId}/v2.0`
*   **Scope:** `api://{GraphQL.Server_client_id}/.default`

**Note:** The exact configuration details will depend on how you're handling configuration in your projects (e.g., `appsettings.json`, environment variables, etc.).

Once configured, run both applications.

### Testing the Authentication with cURL

We can use cURL to test the client credentials flow and make authenticated requests to the GraphQL server.

#### 1. Obtain an Access Token

This command requests an access token from Microsoft Entra ID:

```bash
curl --location '[https://login.microsoftonline.com/](https://login.microsoftonline.com/)<tenant_id>/oauth2/v2.0/token' \
--header 'Content-Type: application/x-www-form-urlencoded' \
--data-urlencode 'client_id=<GraphQL.Client.WebApi_client_id>' \
--data-urlencode 'grant_type=client_credentials' \
--data-urlencode 'scope=api://<GraphQL.Server_client_id>/.default' \
--data-urlencode 'client_secret=<GraphQL.Client.WebApi_client_secret>'
```

### Add Gateway use fusion
To add a gateway to your GraphQL server using Hot Chocolate's Fusion, follow these steps:
https://chillicream.com/docs/fusion/v15/quick-start/
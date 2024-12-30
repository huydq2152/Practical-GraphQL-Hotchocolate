# Getting started with GraphQL on ASP.NET Core and Hot Chocolate - Workshop

Workshop [here](http://workshop.chillicream.com/).

# Use OAuth 2.0 client credentials flow for authen graphql server

## Go to Microsoft Entra ID of an Azure directory

## Go to app registrations and create 2 applications name GraphQL.Server and GraphQL.Client.WebApi

- In GraphQL.Server

1. Because of using client credentials flow, it just authen for application so we need to create an app roles (use app roles menu in left sidebar) with allow member types have applications type

- In GraphQL.Client.WebApi

1. Grant permission need for accessing to GraphQL.Server app

    Go to Api permissions in left sidebar and add a permissions 

    Select APIs my organization uses tab and select GraphQL.Server

    Select Application permissions

    Select all permission that client app need for accessing to GraphQL.Server app

    Grant admin consent confirmation for permissions

2. Create client secrets for client application identify itself

    Go to Certificates & secrets in left sidebar and add new client secret, save secret value for using afterward

## Change config of GraphQL.Server and GraphQL.Client.WebApi match with 2 application just create above and run both of them




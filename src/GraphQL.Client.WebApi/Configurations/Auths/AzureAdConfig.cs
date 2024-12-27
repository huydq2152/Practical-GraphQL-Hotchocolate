using System.Collections.Generic;

namespace GraphQL.Client.WebApi.Configurations.Auths
{
    public class AzureAdConfig
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Authority { get; set; }

        public List<string> Scopes { get; set; }

    }
}

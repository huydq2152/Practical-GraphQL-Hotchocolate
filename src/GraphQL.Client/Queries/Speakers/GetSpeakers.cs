namespace Client.WebApi.Queries.Speakers
{
    public static class GetSpeakers
    {
        public const string Value =
            @"
            query Get {
              getSpeakers: speakers {
                bio
                id
                name
                webSite
              }
            }";
    }
}

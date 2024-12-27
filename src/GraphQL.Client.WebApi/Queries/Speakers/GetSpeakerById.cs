namespace GraphQL.Client.WebApi.Queries.Speakers
{
    public static class GetSpeakerById
    {
        public const string Value =
            @"
            query GetById($id: ID!) {
              getSpeakerById: speakerById(id: $id) {
                id
                name
                bio
                webSite
              }
            }";
    }
}

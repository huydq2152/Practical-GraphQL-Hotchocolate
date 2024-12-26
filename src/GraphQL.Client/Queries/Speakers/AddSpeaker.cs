namespace Client.WebApi.Queries.Speakers
{
    public static class AddSpeaker
    {
        public const string Value =
            @"
            mutation AddSpeaker($name: String!, $bio: String, $webSite: String) {
              addSpeaker: addSpeaker(input: { name: $name, bio: $bio, webSite: $webSite }) {
                speaker {
                  bio
                  id
                  name
                  webSite
                }
                errors {
                  code
                  message
                }
              }
            }";
    }
}

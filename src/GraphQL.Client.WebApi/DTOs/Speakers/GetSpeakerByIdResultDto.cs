using System.Text.Json.Serialization;

namespace GraphQL.Client.WebApi.DTOs.Speakers
{
    public class GetSpeakerByIdResultDto
    {
        [JsonPropertyName("getSpeakerById")]
        public SpeakerDto Speaker { get; set; }
    }
}